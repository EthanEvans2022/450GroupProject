using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //Outlets
    private Collider2D _collider;

    private SpriteRenderer _sprite;
    //Configuration
    public Sprite closedSprite;
    public Sprite openSprite;
    
    public bool isOpen = true;
    
    //State
    
    // Start is called before the first frame update
    void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        SyncIsOpen();
    }

    private void SyncIsOpen()
    {
        //Sprite Change
        //TODO: animation
        print(openSprite);
        print(closedSprite);
        print(isOpen);
        _sprite.sprite = isOpen ? openSprite : closedSprite;

        //Collision toggle
        _collider.enabled = !isOpen;
    }
    
    //TODO: Set is open
    /// <summary>
    /// Set the state of the door. If the door should be open, pass true, if the door should be closed, pass false.
    /// </summary>
    /// <param name="targetOpenState">bool</param>
    public void SetIsOpen(bool targetOpenState)
    {
        isOpen = targetOpenState;
        SyncIsOpen();
    }
}
