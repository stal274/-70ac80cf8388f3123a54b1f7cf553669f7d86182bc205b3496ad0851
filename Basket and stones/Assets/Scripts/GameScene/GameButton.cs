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
            private set { this.value = value; }
        }

        public char Action { get; private set; }

        public int Index
        {
            set
            {
                index = value;
                ButtonsValueGenerate();
            }
        }

        [SerializeField] private int value;
        [SerializeField] private char action;
        [SerializeField] private int index;
        [SerializeField] private BankOfButtonActions bank;

        private void Start()
        {
            bank.GenerateIndex();
        }


        public void OnClick()
        {
            var pg = FindObjectOfType<PlayingGame>();
            GameObject.Find("SFX_Tern_button_" + Random.Range(1, 3)).GetComponent<AudioSource>().Play();
            foreach (var VARIABLE in FindObjectsOfType<GameButton>())
            {
                VARIABLE.GetComponent<Button>().interactable = false;
            }

            pg.WhoseTurn = "Computer";
        }


        private void ButtonsValueGenerate()
        {
            var leftOrRight = gameObject.name == "LeftChoice_Button" ? 0 : 1;
            action = bank.Actions[leftOrRight, index];
            value = bank.ButtonsActionNumericalValue[leftOrRight, index];
            gameObject.GetComponentInChildren<Text>().text =
                action + Convert.ToString(value);
            Action = action;
            Value = value;
        }
    }
}