using UnityEngine;
using UnityEngine.EventSystems;

namespace Comics
{
    public class DragComicsPage : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        private Vector2 startPosition, endPosition;
        private float step = 0.02f;
        private float progress;
        private bool Click;
        private GameObject back0, back1;

        private float length, startY;
        private GameObject ResumeSlide;
        private void Start()
        {
            startY = transform.position.y;
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (Camera.main != null)
            {

                transform.position =
    new Vector2(transform.position.x, Input.mousePosition.y + length);





            }
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            length = transform.position.y -startY ;
        }
    }
}