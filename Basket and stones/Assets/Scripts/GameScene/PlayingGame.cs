using MainScene;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameScene
{
    public class PlayingGame : MonoBehaviour, IPhoneButtons, IPointerDownHandler, IPointerUpHandler
    {
        public GameObject ButtonPanel, WinOrLosePanel;
        [SerializeField] private Text VictoryPanel;
        private Animation Anim;

        public string WhoseTurn
        {
            get { return whoseTurn; }
            set
            {
                whoseTurn = value;
                IsVictory();
            }
        }

        public bool StopGame
        {
            get { return stopGame; }
        }

        [SerializeField] private string whoseTurn;
        private bool stopGame;
        [SerializeField] private Basket basket;
        private readonly byte Difficulty = MainMenu.Difficulty;
        [SerializeField] private int Tick, STick;


        /*private Stones stones;*/

        private void Start()
        {
            basket = FindObjectOfType<Basket>();
            switch (Difficulty)
            {
                case 0:
                    STick = 8;
                    break;
                case 1:
                    STick = 6;
                    break;
                case 2:
                    STick = 4;
                    break;
                default:
                    STick = 4;
                    break;
            }


            /*stones.GetComponent<Stones>();*/
        }


        public void Click(GameObject obj)
        {
            GameObject.Find("SFX_New_Game").GetComponent<AudioSource>().Play();
            switch (obj.name)
            {
                case "Retry_Button":
                    SceneManager.LoadScene("TestGameScene");
                    break;
                case "MainMenu_Button":
                    SceneManager.LoadScene("Main menu");
                    break;
            }
        }


        private void IsVictory()
        {
            Tick += 1;
            if (Tick == STick)
            {
                var bank = FindObjectOfType<BankOfButtonActions>();
                bank.GenerateIndex();
                Tick = 0;
            }

            if (basket.CurrentAmountOfStones != basket.StonesToWin) return;
            WinOrLosePanel.SetActive(true);
            stopGame = true;
            switch (whoseTurn)
            {
                case "Computer":
                    VictoryPanel.text = "Вы выиграли!";
                    GameObject.Find("SFX_Win").GetComponent<AudioSource>().Play();
                    break;
                case "Human":
                    VictoryPanel.text = "Сожалею, но машина оказалась умней!";
                    GameObject.Find("SFX_Lose").GetComponent<AudioSource>().Play();
                    break;
                default:
                    Debug.Log("Ошибка");
                    break;
            }

            if (stopGame)

            {
                ButtonPanel.SetActive(false);
            }
        }


        private void Update()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                HardwareButtons(KeyCode.Escape);
            }
        }

        public void HardwareButtons(KeyCode EscapeButton)
        {
            if (Input.GetKey(EscapeButton))
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