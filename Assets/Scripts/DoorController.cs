using System.Collections.Generic;
using UnityEngine;

namespace FP
{
    public class DoorController : MonoBehaviour
    {
        //Outlets
        private Collider2D _collider;

        private SpriteRenderer _sprite;

        //Configuration
        public Sprite closedSprite;
        public Sprite openSprite;
        public bool inverted;
            
        public Switch[] switches;

        //State
        private bool isOpen = true;
        // Start is called before the first frame update
        void Start()
        {
            _collider = gameObject.GetComponent<Collider2D>();
            _sprite = gameObject.GetComponent<SpriteRenderer>();
            SyncIsOpen();
        }


        public bool GetIsOpen()
        {
            return isOpen ^ inverted;
        }
        private void SyncIsOpen()
        {
            var openFlag = false;
            foreach (var s in switches)
            {
                
                if (s.getIsOn()){
                    openFlag = true;
                }
            }

            isOpen = openFlag;
            //Sprite Change
            //TODO: animation
            print(openSprite);
            print(closedSprite);
            print(GetIsOpen());
            _sprite.sprite = GetIsOpen() ? openSprite : closedSprite;

            //Collision toggle
            _collider.enabled = !GetIsOpen();
        }


        private void Update()
        {
            SyncIsOpen();
        }
    }
}