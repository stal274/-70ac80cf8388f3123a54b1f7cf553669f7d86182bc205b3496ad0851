using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace StudyGameScene
{
    public class GameplayStepsControl : MonoBehaviour, GameScene.IPhoneButtons, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Text victoryPanel, whoseTurnInfo;

        [FormerlySerializedAs("ObjectsToHide")] [SerializeField]
        private GameObject[] objectsToHide;

        private Animation _anim;

        public string WhoseTurn
        {
            get { return whoseTurn; }
            set
            {
                whoseTurn = value;
                WhoseTurnInfoText();
                IsVictory();
            }
        }

        public bool StopGame { get; private set; }

        [SerializeField] private string whoseTurn;
        [SerializeField] private Basket basket;
        private GameObject _studyMask;


        /*private Stones stones;*/

        private void Start()
        {
            basket = FindObjectOfType<Basket>();
            _studyMask = GameObject.Find("StudyMask");
        }

        private void WhoseTurnInfoText()
        {
            if (whoseTurn == "Human")
            {
                whoseTurnInfo.text = "Ваш ход";
            }
            else if (whoseTurn == "Computer") whoseTurnInfo.text = "Ход компьютера";
        }

        private void IsVictory()
        {
            if (basket.CurrentAmountOfStones != basket.StonesToWin)
            {
                return;
            }


            StopGame = true;
            victoryPanel.gameObject.SetActive(true);
            switch (whoseTurn)
            {
                case "Computer":
                    victoryPanel.text = "Вы выиграли!";
                    GameObject.Find("SFX_Win").GetComponent<AudioSource>().Play();
                    break;
                case "Human":
                    victoryPanel.text = "Сожалею, но машина оказалась умней!";
                    GameObject.Find("SFX_Lose").GetComponent<AudioSource>().Play();
                    break;
                default:
                    Debug.Log("Ошибка");
                    break;
            }


            if (!StopGame)
            {
                return;
            }

            foreach (var i in objectsToHide)
            {
                i.SetActive(false);
            }
        }


        private void Update()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                HardwareButtons(KeyCode.Escape);
            }

            if (_studyMask.activeSelf || StopGame)
            {
                whoseTurnInfo.gameObject.SetActive(false);
            }
            else
            {
                whoseTurnInfo.gameObject.SetActive(true);
            }
        }

        public void HardwareButtons(KeyCode escapeButton)
        {
            if (Input.GetKey(escapeButton))
            {
                SceneManager.LoadScene("Main Menu");
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}