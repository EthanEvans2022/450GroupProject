using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class HealthController : MonoBehaviour
{
    [NonSerialized] public UnityEvent<int,DamageType, int, HealthController> BeforeDamageEvent;
    [NonSerialized] public UnityEvent<int,DamageType, int, HealthController>  AfterDamageEvent;
    [NonSerialized] public UnityEvent<int,DamageType, int, HealthController>  BeforeHealEvent;
    [NonSerialized] public UnityEvent<int,DamageType, int, HealthController>  AfterHealEvent;
    
    public enum DamageType
    {
        None,
        Acid,
        Fire,
        Lightning
    }

    public float healInterval = 1f;

    public float acidInterval = 1f;
    public float fireInterval = 1f;
    public float lightningInterval = 1f;

    //config
    public int maxHealth = 100;
    [FormerlySerializedAs("health")] public int currentHealth = 100;

    //State
    private Coroutine[] _damageEffects;

    private IEnumerator DealAcidDamage(int amount, int ticksLeft)
    {
        //Trigger Event
        BeforeDamageEvent.Invoke(amount, DamageType.Acid, ticksLeft, this);
        //Deal the damage
        currentHealth -= amount;

        //Do Extra Effects

        //Trigger Event
        AfterDamageEvent.Invoke(amount, DamageType.Acid, ticksLeft, this);
        
        //Trigger next tick
        if (ticksLeft > 0)
        {
            yield return new WaitForSeconds(acidInterval);
            StartCoroutine(DealAcidDamage(amount, ticksLeft - 1));
        }
    }

    private IEnumerator DealFireDamage(int amount, int ticksLeft)
    {
        //Deal the damage
        currentHealth -= amount;

        //Do Extra Effects

        //Trigger next tick
        if (ticksLeft > 0)
            yield return new WaitForSeconds(acidInterval);
        DealDamage(amount, DamageType.Acid, ticksLeft - 1);
    }

    private IEnumerator DealLightningDamage(int amount, int ticksLeft)
    {
        //Deal the damage
        currentHealth -= amount;

        //Do Extra Effects

        //Trigger next tick
        if (ticksLeft > 0) yield return new WaitForSeconds(acidInterval);
    }

    public IEnumerator Heal(int amount, int ticksLeft = 0, bool removesAllConditions = false, bool canOverHeal = false)
    {
        if (canOverHeal || currentHealth < maxHealth)
        {
            currentHealth += amount;
        }
        
        if (ticksLeft > 0)
        {
            yield return new WaitForSeconds(healInterval);
            StartCoroutine(Heal(amount, ticksLeft - 1));
        }
    }

    public void DealDamage(int amount, DamageType damageType = DamageType.None, int ticksLeft = 0)
    {
        switch (damageType)
        {
            case DamageType.None:
                currentHealth -= amount;
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