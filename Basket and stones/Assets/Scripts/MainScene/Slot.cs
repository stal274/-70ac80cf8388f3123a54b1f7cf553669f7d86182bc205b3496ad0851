using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    private void Start()
    {
    }

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
            var I = 0;
            DragElement.itemBeingDragged.transform.SetParent(transform);
            GameObject.Find("Drop" + Random.Range(0, 6)).GetComponent<AudioSource>().Play();

            for (var i = 0; i < GameObject.FindGameObjectsWithTag("BackpackSlot").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("BackpackSlot")[i].GetComponentsInChildren<Image>().Length == 2)
                {
                    I++;
                }
            }

            var script = FindObjectOfType<BackpackProgressBar>();


            switch (I)
            {
                case 0:
                    script.EndFloat = 0f;
                    break;
                case 3:
                    script.EndFloat = 1f;
                    break;
                default:
                    script.EndFloat = I / 3f;
                    break;
            }

            script.LoadingBackpack();
        }
    }
}