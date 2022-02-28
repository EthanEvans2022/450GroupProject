using System;
using System.Collections;
using UnityEngine;

//  To use this class with composition, use the following command right above any classes which use a healthController
// [RequireComponent(typeof(HealthController))]
// This is preferred to inheritance for simplicity's sake. Use the event listeners to handle the damage controlling.

public class HealthController : MonoBehaviour
{
    //Outlets

    //Connections
    public delegate void DamageEventHandler(int amount, DamageType damageType, int ticksLeft, HealthController target);
    public delegate void HealEventHandler(int amount, int ticksLeft, bool canOverHeal, HealthController target);
    public event DamageEventHandler AfterDamageEvent;
    public event HealEventHandler AfterHealEvent;
    internal event DamageEventHandler BeforeDamageEvent;
    public event HealEventHandler BeforeHealEvent;
    
    //Config
    public enum DamageType
    {
        None,
        Acid,
        Fire,
        Lightning
    }
    
    public int maxHealth = 100;
    public float healInterval = 1f;
    public float acidInterval = 1f;
    public float fireInterval = 1f;
    public float lightningInterval = 1f;
    
    //State
    public int currentHealth = 100;

    //Methods
    public int GetHealth()
    {
        return currentHealth;
    }

    public void Heal(
        int amount,
        int ticksLeft = 0,
        bool canOverHeal = false,
        HealEventHandler localBeforeHealEvent = null,
        HealEventHandler localAfterHealEvent = null
    )
    {
        StartCoroutine(HandleHeal(amount, ticksLeft, canOverHeal, localBeforeHealEvent, localAfterHealEvent));
    }

    private IEnumerator HandleHeal(
        int amount,
        int ticksLeft,
        bool canOverHeal,
        HealEventHandler localBeforeHealEvent = null,
        HealEventHandler localAfterHealEvent = null
    )
    {
        //Trigger Events
        BeforeHealEvent?.Invoke(amount, ticksLeft, canOverHeal, this);
        localBeforeHealEvent?.Invoke(amount, ticksLeft, canOverHeal, this);

        if (canOverHeal || currentHealth < maxHealth) currentHealth += amount;

        //Trigger Events
        AfterHealEvent?.Invoke(amount, ticksLeft, canOverHeal, this);
        localAfterHealEvent?.Invoke(amount, ticksLeft, canOverHeal, this);

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

    public void DealDamage(
        int amount,
        DamageType damageType = DamageType.None,
        int ticksLeft = 0,
        DamageEventHandler localBeforeDamageEvent = null,
        DamageEventHandler localAfterDamageEvent = null
    )
    {
        StartCoroutine(HandleDealDamage(amount, damageType, ticksLeft, localBeforeDamageEvent, localAfterDamageEvent));
    }

    private IEnumerator HandleDealDamage(
        int amount,
        DamageType damageType,
        int ticksLeft,
        DamageEventHandler localBeforeDamageEvent = null,
        DamageEventHandler localAfterDamageEvent = null
    )
    {
        //Trigger Event
        BeforeDamageEvent?.Invoke(amount, DamageType.Acid, ticksLeft, this);
        localBeforeDamageEvent?.Invoke(amount, DamageType.Acid, ticksLeft, this);
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
        AfterDamageEvent?.Invoke(amount, damageType, ticksLeft, this);
        localAfterDamageEvent?.Invoke(amount, DamageType.Acid, ticksLeft, this);

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