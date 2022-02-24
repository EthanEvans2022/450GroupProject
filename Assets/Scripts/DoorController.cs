using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FP
{
    public class DoorController : MonoBehaviour
    {
        //Configuration
        public Sprite closedSprite;
        public Sprite openSprite;
        public bool inverted;
        public Switch[] switches;

        public bool showGizmos = true;
        //Outlets
        private Collider2D _collider;
        private ShadowCaster2D _shadowCaster2D;
        private SpriteRenderer _sprite;

        //State
        private bool isOpen = true;

        // Start is called before the first frame update
        private void Start()
        {
            _collider = gameObject.GetComponent<Collider2D>();
            _sprite = gameObject.GetComponent<SpriteRenderer>();
            _shadowCaster2D = gameObject.GetComponent<ShadowCaster2D>();
            SyncIsOpen();
        }

        private void Update()
        {
            SyncIsOpen();
        }

        private void OnDrawGizmosSelected()
        {
            if (!showGizmos) return;
            Gizmos.color = inverted ? Color.red : Color.blue;
            Gizmos.DrawCube(transform.position, new Vector3(.4f, .4f, .4f));
            foreach (var s in switches)
            {
                var target = s.gameObject.transform;

                // Draws a blue line from this transform to the target
                Gizmos.color = s.inverted ? Color.red : Color.blue;
                Gizmos.DrawLine(transform.position, target.position);
            }
        }


        public bool GetIsOpen()
        {
            return isOpen ^ inverted;
        }

        private void SyncIsOpen()
        {
            var openFlag = false;
            foreach (var s in switches)
                if (s.getIsOn())
                    openFlag = true;

            isOpen = openFlag;
            //Sprite Change
            //TODO: animation
            _sprite.sprite = GetIsOpen() ? openSprite : closedSprite;

            //Collision toggle
            _collider.enabled = !GetIsOpen();

            //Shadow toggle
            _shadowCaster2D.enabled = !GetIsOpen();
        }
    }
}