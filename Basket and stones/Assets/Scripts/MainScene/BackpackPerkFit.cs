using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene
{
    public class BackpackPerkFit : MonoBehaviour
    {
        private void OnEnable()
        {
            var backpack = GameObject.FindGameObjectsWithTag("BackpackSlot");
            foreach (var variable in backpack)
            {
                if (variable.GetComponentsInChildren<Image>().Length != 1) continue;

                var arrayIndex = Array.IndexOf(backpack, variable);
                var skillPrefs = PlayerPrefs.GetString("BackpackSlot" + arrayIndex);
                if (!((IList) GameObject.FindGameObjectsWithTag("Perk")).Contains(GameObject.Find(skillPrefs)) ||
                    skillPrefs == null) continue;

                DragElement.itemBeingDragged = GameObject.Find(skillPrefs);
                DragElement.itemBeingDragged.transform.SetParent(variable.transform, false);
            }
        }
    }
}