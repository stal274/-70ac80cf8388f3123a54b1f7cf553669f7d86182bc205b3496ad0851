using MainScene;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameScene
{
    public class GameplayStepsController : MonoBehaviour, IPhoneButtons
    {
        [SerializeField] private GameObject[] objectsToHide, objectsOfEndGame;
        private Animation _anim;

        public string WhoseTurn
        {
            get { return whoseTurn; }
            set { whoseTurn = value; }
        }


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

        public static GameplayStepsController Instance;

        /*private Stones stones;*/

        private void Awake()
        {
            WhoseTurn = "Human";
            if (Instance != null)
            {
                Debug.LogWarning("Error");
                return;
            }

            Instance = this;

            EventAggregator.GameIsOver.Subscribe(IsVictory);
        }

        private void Start()
        {
            STick = 2 + _difficulty;
            WhoseTurnInfoText();
            /*stones.GetComponent<Stones>();*/
        }


        private void IsVictory(Basket basket)
        {
            foreach (var i in objectsToHide)
            {
                i.SetActive(false);
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

            foreach (var variable in objectsOfEndGame)
            {
                variable.SetActive(true);
            }
        }

        private void WhoseTurnInfoText()
        {
            switch (whoseTurn)
            {
                case "Human":
                    whoseTurnInfo.text = "Ваш ход";
                    break;
                case "Computer":
                    whoseTurnInfo.text = "Ход компьютера";
                    break;
                default:
                    Debug.Log("Error!");
                    break;
            }
        }

        private void ButtonsActionCountingAndEdit()
        {
            if (Tick != STick) return;
            SafeDepositOfButtonActions.Bank.GenerateIndex();
            Tick = 0;
        }


        private void Update()
        {
            if (Application.platform == RuntimePlatform.Android) HardwareButtons(KeyCode.Escape);
        }

        public void HardwareButtons(KeyCode escapeButton)
        {
            if (Input.GetKey(escapeButton)) SceneManager.LoadScene("Main Menu");
        }
    }
}