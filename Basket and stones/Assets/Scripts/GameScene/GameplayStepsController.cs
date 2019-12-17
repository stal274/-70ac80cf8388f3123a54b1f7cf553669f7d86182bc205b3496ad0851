using System.Collections.Generic;
using MainScene;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameScene
{
    public class GameplayStepsController : MonoBehaviour, IPhoneButtons
    {
        public GameObject[] objectsToHide, objectsOfEndGame;
        [SerializeField] private Text whoseTurnInfo;
        [SerializeField] private SafeDepositOfButtonActions bank;
        private Animation _anim;
        [SerializeField] private List<Human> humans;
        [SerializeField] private List<Ai> ais;

        public string WhoseTurn
        {
            get => whoseTurn;
            private set => whoseTurn = value;
        }


        public int Tick
        {
            get => tick;

            set => tick = value;
        }

        public int STick
        {
            private get => sTick;

            set { sTick = value; }
        }

        [SerializeField] private string whoseTurn;
        private readonly byte _difficulty = ChangeDifficultyLevel.Difficulty;
        [SerializeField] private int tick, sTick;

        public static GameplayStepsController Instance;

        /*private Stones stones;*/

        private void Awake()
        {
            SafeDepositOfButtonActions.Instance.GenerateIndex();
            foreach (var human in FindObjectsOfType<Human>()) humans.Add(human);
            foreach (var ai in FindObjectsOfType<Ai>()) ais.Add(ai);
            EventAggregator.EventAggregator.GameIsOver.Subscribe(GameOver);
            EventAggregator.EventAggregator.MoveComplete.Subscribe(ButtonActivitySwitching);
        }

        private void Start()
        {
            Instance = GetComponent<GameplayStepsController>();
            STick = 3 + _difficulty * 2;
            WhoseTurnInfoText();
            /*stones.GetComponent<Stones>();*/
        }

        private void ButtonActivitySwitching(object obj)
        {
            var humanButtons = humans[0].Buttons;

            switch (obj.GetType().ToString())
            {
                case "GameScene.Ai":
                    foreach (var variable in humanButtons)
                    {
                        variable.interactable = true;
                    }

                    WhoseTurn = "Human";
                    GameObject.Find("SFX_Tern_button_" + Random.Range(3, 5)).GetComponent<AudioSource>().Play();
                    break;
                case "GameScene.Human":
                    foreach (var variable in humanButtons)
                    {
                        variable.interactable = false;
                    }

                    Tick += 1;
                    WhoseTurn = "Computer";
                    Ai.Instance.AiStep();
                    break;
            }

            WhoseTurnInfoText();
            ButtonsActionCountingAndEdit();
        }

        private void GameOver(object obj)
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
            switch (WhoseTurn)
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
            if (WhoseTurn != "Human") return;
            if (Tick != STick) return;
            SafeDepositOfButtonActions.Instance.GenerateIndex();
            Tick = 0;
        }


        private void Update()
        {
            if (Application.platform == RuntimePlatform.Android) HardwareButtons(KeyCode.Escape);
        }

        public void HardwareButtons(KeyCode escapeButton)
        {
            if (Input.GetKey(escapeButton)) SceneManager.LoadScene("Main menu");
        }
    }
}