using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Prefabs
{
    public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        private bool _flag;
        private int _timer;
        [SerializeField] private Text descriptionText, actionText;
        [SerializeField] private GameObject panelOfDescription;
        [SerializeField] private GameObject[] objectsToVisible;
        private Text[] _texts;
        private Text[] _texts1;


        private void Start()
        {
            _texts1 = gameObject.GetComponentsInChildren<Text>();
            _texts = gameObject.GetComponentsInChildren<Text>();
        }

        private IEnumerator OnHold()
        {
            yield return new WaitForSeconds(0.5f);

            DescriptionActivation();
        }

        private void DescriptionActivation()
        {
            descriptionText.text = _texts[0].text;
            actionText.text = _texts1[1].text;
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