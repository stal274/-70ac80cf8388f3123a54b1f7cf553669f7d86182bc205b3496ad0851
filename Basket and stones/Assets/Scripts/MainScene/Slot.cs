using UnityEngine;
using UnityEngine.EventSystems;

namespace MainScene
{
    public class Slot : MonoBehaviour, IDropHandler
    {
        private GameObject Item
        {
            get { return transform.childCount > 0 ? transform.GetChild(0).gameObject : null; }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if ((Item || DragElement.elementName != transform.name) && (Item || transform.name != "Backpack slot"))
            {
                return;
            }

            DragElement.itemBeingDragged.transform.SetParent(transform);
            BackpackProgressBar.CheckBackPack();
            GameObject.Find("Drop" + Random.Range(0, 6)).GetComponent<AudioSource>().Play();
        }
    }
}