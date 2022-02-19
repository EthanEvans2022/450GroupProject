using UnityEngine;

public class TrapController : MonoBehaviour
{
    public enum DamageType
    {
        None,
        Acid,
        Fire,
        Lightning
    }


    //Config
    public string[] triggerableEntities;

    public int damageAmount = 10;

    public DamageType damageType = DamageType.None;

    //Outlets
    private BoxCollider2D _boxCollider2D;


    // Start is called before the first frame update
    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print("Trigger");

        foreach (var c in triggerableEntities)
            if (col.gameObject.CompareTag(c))
            {
                DealDamage(col.gameObject);
                break;
            }
    }

    private void DealDamage(GameObject target)
    {
        print("DEALING " + damageAmount + " " + damageType + " DAMAGE TO: " + target);
        
        //Reduce hp by a certain amount if no damage type
        
        //Otherwise act based on damage type (give condition + do some fraction of damage)
    }
}