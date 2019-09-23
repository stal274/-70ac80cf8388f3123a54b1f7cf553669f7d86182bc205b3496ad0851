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

        public int Tick
        {
            get
            {
                return tick;
            }

            set
            {
                tick = value;
            }
        }

        public int STick
        {
            get
            {
                return sTick;
            }

            set
            {
                sTick = value;
            }
        }

        [SerializeField] private string whoseTurn;
        private readonly byte difficulty = ChangeDifficultyLevel.Difficulty;
        [SerializeField] private int tick, sTick;

        public static GameplayStepsControl stepsControl;

        /*private Stones stones;*/

        private void Awake()
        {
            if (stepsControl != null)
            {
                Debug.LogWarning("Error");
                return;
            }
            stepsControl = this;
        }
        private void Start()
        {
            switch (difficulty)
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
            }
        }


        public void IsVictory(bool flag)
        {



            if (Tick == STick)
            {
                SafeDepositOfButtonActions.bank.GenerateIndex();
                Tick = 0;
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
                        objectsOfEndGame[1].GetComponent<Text>().color = new Color(0.6196079f, 0.1333333f, 0.1372549f);
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
                var money = Random.Range(15, 25 * (difficulty + 1));
                Debug.Log(money);
                wallet.FireCoins += money;
                Debug.Log(wallet.FireCoins);

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