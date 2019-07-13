using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainScene
{
    public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static GameObject itemBeingDragged;
        private Vector3 startPosition;
        public static string name;


        public void OnBeginDrag(PointerEventData eventData)
        {
            name = gameObject.name;
            itemBeingDragged = gameObject;
            startPosition = transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.Find("Drag" + Random.Range(0, 4)).GetComponent<AudioSource>().Play();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (Camera.main != null)
                transform.position =
                    Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            itemBeingDragged = null;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            BackpackProgressBar.CheckBackPack();
            if (transform.position != startPosition)
            {
                transform.position = startPosition;
            }
        }
    }
}