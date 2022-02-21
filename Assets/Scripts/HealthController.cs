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

    //config
    public int health = 100;

    public delegate void dealDamageCallback(HealthController self);
    public void dealDamage(int amount, DamageType damageType, dealDamageCallback callback = null)
    {
        health -= amount;
        callback?.Invoke(this);
    }
}
