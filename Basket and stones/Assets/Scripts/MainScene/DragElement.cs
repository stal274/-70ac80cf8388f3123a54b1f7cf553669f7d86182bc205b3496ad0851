using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace MainScene
{
    public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static GameObject itemBeingDragged;
        private Vector3 startPosition;
        public static string elementName;

        [FormerlySerializedAs("FirstParent")] [SerializeField]
        private Transform firstParent;

        [SerializeField] private bool parentIsBackpack;

        private void OnEnable()
        {
            var arrayOfPerkSlot = GameObject.FindGameObjectsWithTag("PerkSlot");
            var arrayOfPerkSlotsName = arrayOfPerkSlot.Select(@object => @object.name).ToList();
            var index = arrayOfPerkSlotsName.IndexOf(gameObject.name + "Slot");
            firstParent = arrayOfPerkSlot[index].GetComponent<Transform>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            elementName = gameObject.name;
            itemBeingDragged = gameObject;
            startPosition = transform.position;
            parentIsBackpack = Math.Abs(itemBeingDragged.GetComponentInParent<GridLayoutGroup>().cellSize.x - 72) <
                               0.01f;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            GameObject.Find("Drag" + Random.Range(0, 4)).GetComponent<AudioSource>().Play();
            var flag = FindObjectOfType<TimerToStartGame>();
            flag.StartTick = false;
            flag.StartTicker();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (Camera.main != null)
            {
                transform.position =
                    Input.mousePosition;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (transform.position == startPosition)
            {
                Debug.LogWarning("������� �� ����������!");
                return;
            }

            if (!parentIsBackpack)
            {
                transform.position = startPosition;
            }
            else
            {
                transform.position = firstParent.position;
                gameObject.transform.SetParent(firstParent);
            }

            itemBeingDragged = null;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            BackpackProgressBar.CheckBackPack();
        }
    }
}