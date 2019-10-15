using MainScene;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameScene
{
    public class GameplayStepsControl : MonoBehaviour, IPhoneButtons
    {
        [SerializeField] private GameObject[] objectsToHide, objectsOfEndGame;
        private Animation Anim;

        public string WhoseTurn
        {
            get { return whoseTurn; }
            set { whoseTurn = value; }
        }

        public bool StopGame { get; private set; }

        public int Tick
        {
            get { return tick; }

            set { tick = value; }
        }

        public int STick
        {
            private get { return sTick; }

            set { sTick = value; }
        }

        [SerializeField] private string whoseTurn;
        private readonly byte _difficulty = ChangeDifficultyLevel.Difficulty;
        [SerializeField] private int tick, sTick;

        public static GameplayStepsControl StepsControl;

        /*private Stones stones;*/

        private void Awake()
        {
            if (StepsControl != null)
            {
                Debug.LogWarning("Error");
                return;
            }

            StepsControl = this;
        }

        private void Start()
        {
            switch (_difficulty)
            {
                case 0:
                    STick = 2;
                    break;
                case 1:
                    STick = 3;
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
                default:
                    Debug.LogWarning("Something wrong!");
                    break;
            }
        }


        public void IsVictory(bool flag)
        {
            ButtonActionChanging();
            if (!flag) return;
            StopGame = true;
            foreach (var i in objectsOfEndGame)
            {
                i.SetActive(true);
            }

            switch (WhoseTurn)
            {
                case "Computer":
                    objectsOfEndGame[1].GetComponent<Text>().color = new Color(0.6196079f, 0.1333333f, 0.1372549f);
                    objectsOfEndGame[1].GetComponent<Text>().text = "Вы выиграли!";
                    GameObject.Find("SFX_Win").GetComponent<AudioSource>().Play();
                    break;
                case "Human":
                    objectsOfEndGame[1].GetComponent<Text>().color = new Color(0.6196079f, 0.1333333f, 0.1372549f);
                    objectsOfEndGame[1].GetComponent<Text>().text = "Сожалею, но машина оказалась умней!";
                    GameObject.Find("SFX_Lose").GetComponent<AudioSource>().Play();
                    break;
                default:
                    Debug.LogWarning("Something wrong!");
                    break;
            }

            // objectsOfEndGame[0].GetComponentInChildren<UnityEngine.Animation>().Play();
            //IncreaseInEarningsOfFireCoins();
            foreach (var i in objectsToHide)
            {
                i.SetActive(false);
            }
        }

        private void IncreaseInEarningsOfFireCoins()
        {
            var wallet = gameObject.AddComponent<Wallet>();
            var money = Random.Range(15, 25 * (_difficulty + 1));
            wallet.FireCoins += money;
        }

        private void ButtonActionChanging()
        {
            if (Tick != STick) return;
            SafeDepositOfButtonActions.Bank.GenerateIndex();
            Tick = 0;
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
            if (Input.GetKey(escapeButton)) SceneManager.LoadScene("Main Menu");
        }
    }
}