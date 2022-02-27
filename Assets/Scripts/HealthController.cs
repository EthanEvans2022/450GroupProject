using System;
using System.Collections;
using UnityEngine;
using healEvent = UnityEngine.Events.UnityEvent<int, int, bool, HealthController>;
using damageEvent = UnityEngine.Events.UnityEvent<int, HealthController.DamageType, int, HealthController>;

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
    [NonSerialized] public readonly damageEvent AfterDamageEvent = new();
    [NonSerialized] public readonly healEvent AfterHealEvent = new();
    [NonSerialized] public readonly damageEvent BeforeDamageEvent = new();
    [NonSerialized] public readonly healEvent BeforeHealEvent = new();

    public (healEvent, healEvent) Heal(int amount, int ticksLeft = 0, bool canOverHeal = false)
    {
        healEvent localBeforeHealEvent = new();
        healEvent localAfterHealEvent = new();
        StartCoroutine(HandleHeal(amount, ticksLeft, canOverHeal, localBeforeHealEvent, localAfterHealEvent));
        return (localBeforeHealEvent, localAfterHealEvent);
    }

    private IEnumerator HandleHeal(
        int amount,
        int ticksLeft,
        bool canOverHeal,
        healEvent localBeforeHealEvent,
        healEvent localAfterHealEvent
    )
    {
        //Trigger Events
        BeforeHealEvent.Invoke(amount, ticksLeft, canOverHeal, this);
        localBeforeHealEvent.Invoke(amount, ticksLeft, canOverHeal, this);

        if (canOverHeal || currentHealth < maxHealth) currentHealth += amount;

        //Other Effects


        //Trigger Events
        AfterHealEvent.Invoke(amount, ticksLeft, canOverHeal, this);
        localAfterHealEvent.Invoke(amount, ticksLeft, canOverHeal, this);

        if (ticksLeft > 0)
        {
            yield return new WaitForSeconds(healInterval);
            StartCoroutine(HandleHeal(amount, ticksLeft - 1, canOverHeal, localBeforeHealEvent, localAfterHealEvent));
        }
    }

    public void RemoveAllEffects()
    {
        StopAllCoroutines();
    }

    public (damageEvent, damageEvent) DealDamage(int amount, DamageType damageType = DamageType.None, int ticksLeft = 0)
    {
        damageEvent localBeforeDamageEvent = new();
        damageEvent localAfterDamageEvent = new();
        StartCoroutine(HandleDealDamage(amount, damageType, ticksLeft, localBeforeDamageEvent, localAfterDamageEvent));
        return (localBeforeDamageEvent, localAfterDamageEvent);
    }

    private IEnumerator HandleDealDamage(
        int amount,
        DamageType damageType,
        int ticksLeft,
        damageEvent localBeforeDamageEvent,
        damageEvent localAfterDamageEvent
    )
    {
        //Trigger Event
        BeforeDamageEvent.Invoke(amount, DamageType.Acid, ticksLeft, this);
        localBeforeDamageEvent.Invoke(amount, DamageType.Acid, ticksLeft, this);
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
        localAfterDamageEvent.Invoke(amount, DamageType.Acid, ticksLeft, this);

        //Trigger next tick if there are ticks left and the damage can trigger again
        if (ticksLeft > 0 && damageType != DamageType.None)
        {
            yield return new WaitForSeconds(acidInterval);
            StartCoroutine(
                HandleDealDamage(amount, damageType, ticksLeft - 1, localBeforeDamageEvent, localAfterDamageEvent)
            );
        }
    }
}