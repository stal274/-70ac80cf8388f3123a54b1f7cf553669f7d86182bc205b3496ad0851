using MainScene;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameScene
{
    public class GameplayStepsControl : MonoBehaviour, IPhoneButtons, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private GameObject[] objectsToHide, objectsOfEndGame;
        private Animation Anim;

        public string WhoseTurn
        {
            get { return whoseTurn; }
            set
            {
                whoseTurn = value;
            }
        }

        public bool StopGame { get; private set; }

        [SerializeField] private string whoseTurn;
        [SerializeField] private Basket basket;
        [SerializeField] private SafeDepositOfButtonActions bank;

        private readonly byte difficulty = ChangeDifficultyLevel.Difficulty;
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
            if (bank != null)
            {
                bank.GenerateIndex();
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


        public void IsVictory(bool flag)
        {


            tick += 1;
            if (tick == sTick)
            {
                var bank = FindObjectOfType<SafeDepositOfButtonActions>();
                bank.GenerateIndex();
                tick = 0;
            }


            if (flag)
            {

                foreach (var i in objectsOfEndGame)
                {
                    i.SetActive(true);
                }
                StopGame = true;
                switch (WhoseTurn)
                {
                    case "Computer":
                        objectsOfEndGame[1].GetComponent<Text>().color = new Color(0.1490196f, 0.7921569f, 0.8980392f);
                        objectsOfEndGame[1].GetComponent<Text>().text = "Вы выиграли!";
                        GameObject.Find("SFX_Win").GetComponent<AudioSource>().Play();
                        break;
                    case "Human":
                        objectsOfEndGame[1].GetComponent<Text>().color = new Color(0.6196079f, 0.1333333f, 0.1372549f);
                        objectsOfEndGame[1].GetComponent<Text>().text = "Сожалею, но машина оказалась умней!";
                        GameObject.Find("SFX_Lose").GetComponent<AudioSource>().Play();
                        break;

                }

                // objectsOfEndGame[0].GetComponentInChildren<UnityEngine.Animation>().Play();


                 var wallet = gameObject.AddComponent<Wallet>();
                 wallet.FireCoins += Random.Range(15, 25 * difficulty)+ PlayerPrefs.GetInt("Wallet");
                PlayerPrefs.SetInt("Wallet", wallet.FireCoins);

                foreach (var i in objectsToHide)
                {
                    i.SetActive(false);
                }
            }
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