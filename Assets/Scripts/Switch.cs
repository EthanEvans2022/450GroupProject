using System.Globalization;
using UnityEngine;


public class Switch : MonoBehaviour
{
    //Connections
    

    //Config
    public Collider2D[] targetDoors;
    public Collider2D[] triggerableEntities;

    public enum Mode
    {
        Permanent, Timed, Toggle 
    }
    
    public Mode switchMode = Mode.Permanent;
    //State

    //Methods
    void OnTriggerEnter2D(Collider2D collision)
    {
        var doTrigger = false;
        foreach (var c in triggerableEntities)
        {
            if (c == collision) doTrigger = true;
        }

        if (doTrigger)
        {
            foreach (var c in targetDoors)
            {

                print("TRIGGER");
                switch (switchMode)
                {
                    case Mode.Permanent:
                        c.enabled = false;
                        break;
                    case Mode.Timed:
                        c.enabled = false;
                       //Not Sure How to implement this
                        break;
                    case Mode.Toggle:
                        c.enabled = !c.enabled;
                        break;
                }

            }
        }
    }
}
