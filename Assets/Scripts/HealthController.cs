using System;
using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public enum DamageType
    {
        None,
        Acid,
        Fire,
        Lightning
    }

    public float acidInterval = 1f;
    public float fireInterval = 1f;
    public float lightningInterval = 1f;

    //config
    public int health = 100;

    //State
    private Coroutine[] _damageEffects;

    private IEnumerator DealAcidDamage(int amount, int ticksLeft)
    {
        //Deal the damage
        health -= amount;

        //Do Extra Effects

        if (ticksLeft > 0)
            yield return new WaitForSeconds(acidInterval);
        DealDamage(amount, DamageType.Acid, ticksLeft - 1);
    }

    private IEnumerator DealFireDamage(int amount, int ticksLeft)
    {
        health -= amount;
        if (ticksLeft > 0)
            yield return new WaitForSeconds(acidInterval);
        DealDamage(amount, DamageType.Acid, ticksLeft - 1);
    }

    private IEnumerator DealLightningDamage(int amount, int ticksLeft)
    {
        health -= amount;
        if (ticksLeft > 0)
            yield return new WaitForSeconds(acidInterval);
        DealDamage(amount, DamageType.Acid, ticksLeft - 1);
    }

    public void DealDamage(int amount, DamageType damageType = DamageType.None, int ticksLeft = 0)
    {
        switch (damageType)
        {
            case DamageType.None:
                health -= amount;
                break;
            case DamageType.Acid:
                //Deal damage, then start doing effects
                StartCoroutine(DealAcidDamage(amount, ticksLeft));
                break;
            case DamageType.Fire:
                StartCoroutine(DealFireDamage(amount, ticksLeft));
                break;
            case DamageType.Lightning:
                StartCoroutine(DealLightningDamage(amount, ticksLeft));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(damageType), damageType, null);
        }
    }
}