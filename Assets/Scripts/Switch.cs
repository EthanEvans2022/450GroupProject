using System;
using System.Collections;
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
        public Sprite offSprite;
        public Sprite onSprite;

        public float switchDelay = 3;
        
        public Mode switchMode = Mode.Permanent;

        //State
        private bool isOn = false;

        //Methods
        private void Start()
        {
            _sprite = gameObject.GetComponent<SpriteRenderer>();
            _sprite.sprite = isOn ? onSprite : offSprite;
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
        
        //turn the switch off after x seconds
        private IEnumerator StartSwitchTimer()
        {
            yield return new WaitForSeconds(switchDelay);
            isOn = false;
            _sprite.sprite = isOn ? onSprite : offSprite;
        }
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            var doTrigger = false;
            foreach (var c in triggerableEntities)
                if (collision.gameObject.GetComponent<CharacterMovement>() &&
                    collision.gameObject.CompareTag(c))
                    doTrigger = true;

            if (doTrigger) StartCoroutine(StartSwitchTimer());
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
            _sprite.sprite = isOn ? onSprite : offSprite;
        }
    }
}