using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToExit : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject[] objectsToVisible;

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        foreach (var VARIABLE in objectsToVisible)
        {
            VARIABLE.SetActive(true);
        }
    }
}