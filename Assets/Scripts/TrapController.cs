using UnityEngine;

public class TrapController : MonoBehaviour
{
    //Config
    public string[] triggerableEntities;

    public int damageAmount = 10;

    public HealthController.DamageType damageType = HealthController.DamageType.None;


    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print("Trigger");

        foreach (var c in triggerableEntities)
            if (col.gameObject.GetComponent<HealthController>() && col.gameObject.CompareTag(c))
            {
                DealDamage(col.gameObject.GetComponent<HealthController>());
                break;
            }
    }

    private void DealDamage(HealthController target)
    {
        print("DEALING " + damageAmount + " " + damageType + " DAMAGE TO: " + target);

        var (before, after) = target.DealDamage(damageAmount, damageType, 3);
        var time = Time.time;
        before.AddListener((arg0, type, i, arg3) => print("Just this one source" + time));
    }
}