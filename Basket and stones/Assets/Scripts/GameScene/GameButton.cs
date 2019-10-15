using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameScene
{
    public class GameButton : MonoBehaviour
    {
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public char Action
        {
            get { return action; }
            set { action = value; }
        }

        public int NumberOfGameButton { get; private set; }


        [SerializeField] private int value;
        [SerializeField] private char action;
        [SerializeField] private Text actionAndValueText;

        private void Start()
        {
            NumberOfGameButton = Array.IndexOf(GameObject.FindObjectsOfType<GameButton>(),
                gameObject.GetComponent<GameButton>());
            actionAndValueText = gameObject.GetComponentInChildren<Text>();
            SafeDepositOfButtonActions.Bank.GenerateIndex();
        }


        public void OnClick()
        {
            GameObject.Find("SFX_Tern_button_" + Random.Range(1, 3)).GetComponent<AudioSource>().Play();
            foreach (var VARIABLE in FindObjectsOfType<GameButton>())
            {
                VARIABLE.GetComponent<Button>().interactable = false;
            }

            GameplayStepsController.StepsController.WhoseTurn = "Computer";
            GameplayStepsController.StepsController.Tick += 1;
        }


        public void ButtonsActionAndValueEditing()
        {
            actionAndValueText.text =
                Action + Convert.ToString(Value);
        }
    }
}