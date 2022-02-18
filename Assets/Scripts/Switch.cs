using System;
using System.Collections;
using Unity.VisualScripting;
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

        //TODO: Make this matter in all modes using it as a time to activate the outgoing signal
        public float switchDelay = 0;
        
        public Mode switchMode = Mode.Permanent;

        //State
        private bool isOn = false;

        private Coroutine _currentRoutine;
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
                if (collision.gameObject.CompareTag(c))
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
                if (collision.gameObject.CompareTag(c))
                    doTrigger = true;

            if (doTrigger && switchMode == Mode.Timed)
            {
                print("MADE IT HERE");
                if(!_currentRoutine.IsUnityNull()) StopCoroutine(_currentRoutine);
                _currentRoutine = StartCoroutine(StartSwitchTimer());
            }
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
                case Mode.Timed:
                    isOn = true;
                    break;
                case Mode.Toggle:
                    isOn = !isOn;
                    break;
            }
            _sprite.sprite = isOn ? onSprite : offSprite;
        }
    }
}