using Unity.VisualScripting;
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
        {
            var h = col.gameObject.GetComponent<HealthController>();
            if (!h)
            {
                h = col.gameObject.GetComponentInParent<HealthController>();
            }

            if (h && (col.gameObject.CompareTag(c) || h.gameObject.CompareTag(c)))
            {
                DealDamage(h);
                break;
            }
        }
    }

    private void DealDamage(HealthController target)
        {
            print("DEALING " + damageAmount + " " + damageType + " DAMAGE TO: " + target);

            var time = Time.time;
            target.DealDamage(
                damageAmount,
                damageType,
                3,
                localAfterDamageEvent: (arg0, type, i, arg3) => print("Just this one source" + time)
            );
        }
    
}