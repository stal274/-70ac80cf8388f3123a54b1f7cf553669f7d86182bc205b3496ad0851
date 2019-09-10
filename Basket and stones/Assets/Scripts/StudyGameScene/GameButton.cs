using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace StudyGameScene
{
    public class GameButton : MonoBehaviour
    {
        public int Value
        {
            get { return value; }
            private set { this.value = value; }
        }

        public char Action { get; private set; }



        [SerializeField] private int value;
        [SerializeField] private char action;


        private void Start()
        {
            var leftOrRight = gameObject.name == "LeftChoice_Button" ? 0 : 1;
            Action = gameObject.GetComponentInChildren<Text>().text[0];
            Value = System.Convert.ToInt32(gameObject.GetComponentInChildren<Text>().text[1].ToString());
        }


        public void OnClick()
        {
            var flag = FindObjectOfType<GameplayStepsControl>().StopGame;

            GameObject.Find("SFX_Tern_button_" + Random.Range(1, 3)).GetComponent<AudioSource>().Play();
            foreach (var VARIABLE in FindObjectsOfType<GameButton>())
            {
                VARIABLE.GetComponent<Button>().interactable = false;
            }
            if (flag)
            {
                return;
            }

            var pg = FindObjectOfType<GameplayStepsControl>();
            pg.WhoseTurn = "Computer";
        }



    }
}