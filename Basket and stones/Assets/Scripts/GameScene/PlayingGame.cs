using MainScene;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameScene
{
    public class PlayingGame : MonoBehaviour, IPhoneButtons, IPointerDownHandler, IPointerUpHandler
    {
        public GameObject buttonPanel, winOrLosePanel;
        [SerializeField] private Text victoryPanel;
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

        public bool StopGame { get; private set; }

        [SerializeField] private string whoseTurn;
        [SerializeField] private Basket basket;
        private readonly byte difficulty = MainMenu.Difficulty;
        [SerializeField] private int tick, sTick;


        /*private Stones stones;*/

        private void Start()
        {
            basket = FindObjectOfType<Basket>();
            switch (difficulty)
            {
                case 0:
                    sTick = 8;
                    break;
                case 1:
                    sTick = 6;
                    break;
                case 2:
                    sTick = 4;
                    break;
                default:
                    sTick = 4;
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
            tick += 1;
            if (tick == sTick)
            {
                var bank = FindObjectOfType<BankOfButtonActions>();
                bank.GenerateIndex();
                tick = 0;
            }

            if (basket.CurrentAmountOfStones != basket.StonesToWin)
            {
                return;
            }

            winOrLosePanel.SetActive(true);
            StopGame = true;
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

            winOrLosePanel.GetComponentInChildren<UnityEngine.Animation>().Play();
            if (!StopGame)
            {
                return;
            }

            {
                var wallet = gameObject.AddComponent<Wallet>();
                wallet.FireCoins += Random.Range(15, 25 * difficulty);
            }


            buttonPanel.SetActive(false);
        }


        private void Update()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                HardwareButtons(KeyCode.Escape);
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