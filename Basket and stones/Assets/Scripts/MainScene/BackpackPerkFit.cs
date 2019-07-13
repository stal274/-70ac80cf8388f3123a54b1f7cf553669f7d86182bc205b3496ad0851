using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene
{
    public class BackpackPerkFit : MonoBehaviour
    {
        [SerializeField] private GameObject[] BackpackSlots;

        private void Start()
        {
            for (var i = 0; i < BackpackSlots.Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("BackpackSlot")[i].GetComponentsInChildren<Image>().Length == 1)
                {
                    if (!((IList) GameObject.FindGameObjectsWithTag("Perk"))
                            .Contains(GameObject.Find(PlayerPrefs.GetString("BackpackSlot" + i))) ||
                        PlayerPrefs.GetString("BackpackSlot" + i) == null) continue;
                    DragElement.itemBeingDragged = GameObject.Find(PlayerPrefs.GetString("BackpackSlot" + i));
                    DragElement.itemBeingDragged.transform.SetParent(BackpackSlots[i].transform);
                }
            }
        }
    }
}