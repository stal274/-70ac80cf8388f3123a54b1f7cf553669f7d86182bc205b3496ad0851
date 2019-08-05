using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Prefabs
{
    public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        private bool flag;
        private int timer;
        [SerializeField] private Text descriptionText, actionText;
        [SerializeField] private GameObject panelOfDescription;
        [SerializeField] private GameObject[] objectsToVisible;


        private IEnumerator OnHold()
        {
            yield return new WaitForSeconds(0.5f);

            DescriptionActivation();
        }

        private void DescriptionActivation()
        {
            descriptionText.text = gameObject.GetComponentsInChildren<Text>()[0].text;
            actionText.text = gameObject.GetComponentsInChildren<Text>()[1].text;
            panelOfDescription.SetActive(true);


            foreach (var VARIABLE in objectsToVisible)
            {
                VARIABLE.SetActive(false);
            }
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            StartCoroutine(OnHold());
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            StopAllCoroutines();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StopAllCoroutines();
        }
    }
}