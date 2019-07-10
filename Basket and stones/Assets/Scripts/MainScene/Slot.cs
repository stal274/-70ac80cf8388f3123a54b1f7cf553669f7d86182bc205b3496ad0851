using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }

            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item && DragElement.name == transform.name || !item && transform.name == "Backpack slot")
        {
            DragElement.itemBeingDragged.transform.SetParent(transform);
            GameObject.Find("Drop" + Random.Range(0, 6)).GetComponent<AudioSource>().Play();
        }
    }
}