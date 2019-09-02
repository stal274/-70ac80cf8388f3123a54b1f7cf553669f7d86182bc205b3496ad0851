using GameScene;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToExit : MonoBehaviour, IPointerDownHandler, IPhoneButtons
{
    [SerializeField] private GameObject[] objectsToVisible;

    private void Update()
    {
        if (!gameObject.activeSelf)
        {
            return;
        }

        if (Application.platform != RuntimePlatform.Android)
        {
            return;
        }
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        HardwareButtons(KeyCode.Escape);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Exit();
    }

    public void HardwareButtons(KeyCode escapeButton)
    {
        if (!Input.GetKeyDown(escapeButton))
        {
            return;
        }

        Exit();
    }
 
    private void Exit()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        foreach (var VARIABLE in objectsToVisible)
        {
            VARIABLE.SetActive(true);
        }
    }
}