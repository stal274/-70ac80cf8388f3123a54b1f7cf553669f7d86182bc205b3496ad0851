using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace MainScene
{
    public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static GameObject itemBeingDragged;
        private Vector3 startPosition;
        public static string name;
        [SerializeField] private Transform FirstParent;

        [SerializeField] private bool parentIsBackpack;

        private void Start()
        {
            for (var i = 0; i < GameObject.FindGameObjectsWithTag("PerkSlot").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("PerkSlot")[i].name != gameObject.name) continue;
                FirstParent = GameObject.FindGameObjectsWithTag("PerkSlot")[i].transform;
                break;
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            name = gameObject.name;
            itemBeingDragged = gameObject;
            startPosition = transform.position;
            parentIsBackpack = Math.Abs(itemBeingDragged.GetComponentInParent<GridLayoutGroup>().cellSize.x - 72) <
                               0.01f;
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
            if (transform.position == startPosition) return;
            transform.position = parentIsBackpack
                ? FirstParent.position
                : startPosition;
            if (parentIsBackpack)
            {
                gameObject.transform.SetParent(FirstParent);
            }
        }
    }
}