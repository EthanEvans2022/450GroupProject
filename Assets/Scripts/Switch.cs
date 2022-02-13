using System;
using UnityEngine;

namespace FP
{
    public class Switch : MonoBehaviour
    {
        //Outlets 
        private SpriteRenderer _sprite;
        
        public enum Mode
        {
            Permanent,
            Timed,
            Toggle
        }
        //Connections


        //Config
        public bool inverted = false;
        public string[] triggerableEntities;
        public Sprite closedSprite;
        public Sprite openSprite;
        
        public Mode switchMode = Mode.Permanent;

        //State
        private bool isOn = false;

        //Methods
        private void Start()
        {
            _sprite = gameObject.GetComponent<SpriteRenderer>();
            _sprite.sprite = isOn ? openSprite : closedSprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var doTrigger = false;
            foreach (var c in triggerableEntities)
                if (collision.gameObject.GetComponent<CharacterMovement>() &&
                    collision.gameObject.CompareTag(c))
                    doTrigger = true;

            if (doTrigger) setIsOn();
        }

        public bool getIsOn()
        {
            return isOn ^ inverted;
        }

        private void setIsOn()
        {
            print("TRIGGER");
            switch (switchMode)
            {
                case Mode.Permanent:
                    isOn = true;
                    break;
                case Mode.Timed:
                    isOn = true;
                    //Not Sure How to implement this
                    break;
                case Mode.Toggle:
                    isOn = !isOn;
                    break;
            }
            _sprite.sprite = isOn ? openSprite : closedSprite;
        }
    }
}