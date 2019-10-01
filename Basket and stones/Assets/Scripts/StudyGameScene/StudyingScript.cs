using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace StudyGameScene
{
    public class StudyingScript : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Transform clickableObject;
        [SerializeField] private Transform[] firstParent;
#pragma warning disable 414
        private bool _clickable = true;
#pragma warning restore 414
        [FormerlySerializedAs("i")] [SerializeField] private byte studyTextCount = 0;
        [SerializeField] private GameObject[] objectsToStudy, studyTexts;
        private Basket _basket;

        private void OnEnable()
        {
            if (studyTextCount == 0)
            {
                return;
            }


            StudyStepActivation();
        }

        private void Start()
        {
            studyTexts[0].SetActive(true);
            _basket = FindObjectOfType<Basket>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (studyTextCount == studyTexts.Length - 1)
            {
                PlayerPrefs.SetInt("IsStudy", 1);
                Player.Wallet.wallet.FireCoins = 250;
                SceneManager.LoadScene("Main menu");
                return;
            }

            if (GameObject.Find("StudyMask").GetComponentsInChildren<Button>().Length > 0)
            {
                return;
            }

            Restoration();
            StudyStepActivation();
        }

        public void OnClick()
        {
            Restoration();
            objectsToStudy[studyTextCount - 1].transform.SetParent(firstParent[studyTextCount - 1]);
            studyTexts[studyTextCount].SetActive(false);
        }

        private void StudyStepActivation()
        {
            if (studyTextCount < objectsToStudy.Length)
            {
                if (objectsToStudy[studyTextCount] != null)
                {
                    objectsToStudy[studyTextCount].transform.SetParent(clickableObject);

                    foreach (var variable in objectsToStudy[studyTextCount].GetComponentsInChildren<Animation>())
                    {
                        variable.Play();
                    }
                }
            }

            studyTexts[studyTextCount].SetActive(false);
            studyTexts[studyTextCount + 1].SetActive(true);
            studyTextCount++;
        }

        private void Restoration()
        {
            if (studyTextCount <= 0) return;
            if (studyTextCount + 1 > objectsToStudy.Length || objectsToStudy[studyTextCount - 1] == null) return;
            objectsToStudy[studyTextCount - 1].transform.SetParent(firstParent[studyTextCount - 1]);
            foreach (var variable in objectsToStudy[studyTextCount - 1].GetComponentsInChildren<Animation>())
            {
                variable.Stop();
            }

            foreach (var variable in objectsToStudy[studyTextCount - 1].GetComponentsInChildren<Image>())
            {
                var color = variable.color;
                color = new Color(color.r, color.g, color.b, 1f);
                variable.color = color;
            }

            foreach (var variable in objectsToStudy[studyTextCount - 1].GetComponentsInChildren<Text>())
            {
                var color = variable.color;
                color = new Color(color.r, color.g, color.b, 1f);
                variable.color = color;
            }
        }
    }
}