using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StudyGameScene
{
    public class StudyingScript : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Transform ClickableObject;
        [SerializeField] private Transform[] FirstParent;
        private bool Clickable = true;
        [SerializeField] private byte i = 0;
        [SerializeField] private GameObject[] ObjectsToStudy, StudyTexts;
        private Basket Basket;

        private void OnEnable()
        {
            if (i == 0)
            {
                return;
            }

           
            StudyStepActivation();
        }
        private void Start()
        {
           
            StudyTexts[0].SetActive(true);
            Basket = FindObjectOfType<Basket>();


        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (i == StudyTexts.Length-1)
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
            ObjectsToStudy[i - 1].transform.SetParent(FirstParent[i - 1]);
            StudyTexts[i].SetActive(false);


        }

        private void StudyStepActivation()
        {
            if (i < ObjectsToStudy.Length)
            {
                if (ObjectsToStudy[i] != null)
                {
                    ObjectsToStudy[i].transform.SetParent(ClickableObject);

                    foreach (var i in ObjectsToStudy[i].GetComponentsInChildren<Animation>())
                    {
                        i.Play();
                    }


                }


            }
            StudyTexts[i].SetActive(false); 
            StudyTexts[i + 1].SetActive(true);
            i++;


        }
        private void Restoration()
        {
            if (i > 0)
            {
                if (i + 1 <= ObjectsToStudy.Length && ObjectsToStudy[i - 1] != null)
                {
                    ObjectsToStudy[i - 1].transform.SetParent(FirstParent[i - 1]);
                    foreach (var i in ObjectsToStudy[i - 1].GetComponentsInChildren<Animation>())
                    {
                        i.Stop();

                    }
                    foreach (var i in ObjectsToStudy[i - 1].GetComponentsInChildren<Image>())
                    {
                        i.color = new Color(i.color.r, i.color.g, i.color.b, 1f);
                    }
                    foreach (var i in ObjectsToStudy[i - 1].GetComponentsInChildren<Text>())
                    {
                        i.color = new Color(i.color.r, i.color.g, i.color.b, 1f);
                    }
                }
            }
        }

    }
}