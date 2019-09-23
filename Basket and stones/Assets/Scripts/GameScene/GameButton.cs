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

        public char Action { get { return action; } set { action = value; } }

        public int NumberOfGameButton { get; private set; }



        [SerializeField] private int value;
        [SerializeField] private char action;

        private void Start()
        {

            NumberOfGameButton = Array.IndexOf(GameObject.FindObjectsOfType<GameButton>(), gameObject.GetComponent<GameButton>());
            SafeDepositOfButtonActions.bank.GenerateIndex();
        }


        public void OnClick()
        {

            GameObject.Find("SFX_Tern_button_" + Random.Range(1, 3)).GetComponent<AudioSource>().Play();
            foreach (var VARIABLE in FindObjectsOfType<GameButton>())
            {
                VARIABLE.GetComponent<Button>().interactable = false;
            }

            GameplayStepsControl.stepsControl.WhoseTurn = "Computer";
            GameplayStepsControl.stepsControl.Tick += 1;
        }


        public void ButtonsValueGenerate()
        {
            gameObject.GetComponentInChildren<Text>().text =
             Action + Convert.ToString(Value);
        }
    }
}