using UnityEngine;
using UnityEngine.UI;

namespace GameScene
{
    public partial class GameplayStepsController
    {
        [SerializeField] private GameObject[] objectsToHide;
        [SerializeField] private GameObject[] objectsOfEndGame;

        public string WhoseTurn
        {
            get { return whoseTurn; }
            set { whoseTurn = value; }
        }

        public bool StopGame { get; private set; }
        [SerializeField] private string whoseTurn;
        [SerializeField] private int tick;
        [SerializeField] private int sTick;

        public void IsVictory(bool flag)
        {
            ButtonsActionCountingAndEdit();
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
    }
}