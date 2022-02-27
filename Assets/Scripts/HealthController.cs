using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
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
    public int currentHealth = 100;
    [NonSerialized] public readonly UnityEvent<int, DamageType, int, HealthController> AfterDamageEvent = new();
    [NonSerialized] public readonly UnityEvent<int, int, bool, HealthController> AfterHealEvent = new();
    [NonSerialized] public readonly UnityEvent<int, DamageType, int, HealthController> BeforeDamageEvent = new();
    [NonSerialized] public readonly UnityEvent<int, int, bool, HealthController> BeforeHealEvent  = new();

    public void Heal(int amount, int ticksLeft = 0, bool canOverHeal = false)
    {
        StartCoroutine(HandleHeal(amount, ticksLeft, canOverHeal));
    }

    private IEnumerator HandleHeal(int amount, int ticksLeft, bool canOverHeal)
    {
        //Trigger Event
        BeforeHealEvent.Invoke(amount, ticksLeft, canOverHeal, this);

        if (canOverHeal || currentHealth < maxHealth) currentHealth += amount;

        //Other Effects


        //Trigger Effect
        AfterHealEvent.Invoke(amount, ticksLeft, canOverHeal, this);

        if (ticksLeft > 0)
        {
            yield return new WaitForSeconds(healInterval);
            StartCoroutine(HandleHeal(amount, ticksLeft - 1, canOverHeal));
        }
    }

    public void RemoveAllEffects()
    {
        StopAllCoroutines();
    }

    public void DealDamage(int amount, DamageType damageType = DamageType.None, int ticksLeft = 0)
    {
        StartCoroutine(HandleDealDamage(amount, damageType, ticksLeft));
    }

    private IEnumerator HandleDealDamage(int amount, DamageType damageType = DamageType.None, int ticksLeft = 0)
    {
        //Trigger Event
        BeforeDamageEvent.Invoke(amount, DamageType.Acid, ticksLeft, this);

        //Deal Damage
        switch (damageType)
        {
            case DamageType.None:
                currentHealth -= amount;
                break;
            case DamageType.Acid:
                //Deal damage, then start doing effects
                currentHealth -= amount;
                break;
            case DamageType.Fire:
                currentHealth -= amount;

                break;
            case DamageType.Lightning:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(damageType), damageType, null);
        }

        //Trigger Event
        AfterDamageEvent.Invoke(amount, damageType, ticksLeft, this);

        //Trigger next tick if there are ticks left and the damage can trigger again
        if (ticksLeft > 0 && damageType != DamageType.None)
        {
            yield return new WaitForSeconds(acidInterval);
            StartCoroutine(HandleDealDamage(amount, damageType, ticksLeft - 1));
        }
    }
}