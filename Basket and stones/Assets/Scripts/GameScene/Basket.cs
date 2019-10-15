using System;
using System.Collections;
using MainScene;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameScene
{
    public class Basket : MonoBehaviour
    {
        private readonly byte _difficulty = ChangeDifficultyLevel.Difficulty;
        [SerializeField] private Text currentAmountOfStonesPanel, stonesToWinPanel;
        [SerializeField] private int currentAmountOfStones, stonesToWin;
        public static Basket basket;

        public int StonesToWin
        {
            get { return stonesToWin; }
            private set { stonesToWin = value; }
        }


        public int CurrentAmountOfStones
        {
            get { return currentAmountOfStones; }
            set { currentAmountOfStones = value; }
        }

        private void Awake()
        {
            if (basket != null)
            {
                Debug.LogWarning("Error");
                return;
            }

            basket = this;
        }

        private void Start()
        {
            var i = 0;
            if (_difficulty == 0)
            {
                i = Random.Range(10, 26);
            }
            else if (_difficulty == 1)
            {
                i = Random.Range(26, 40);
            }
            else if (_difficulty == 2)
            {
                i = Random.Range(41, 56);
            }
            else
            {
                i = Random.Range(26, 40);
            }

            CurrentAmountOfStones = i;
            var min = i * 1.3f;
            var max = i * 2.2f;
            StonesToWin = Convert.ToInt32(Random.Range(min, max));
            stonesToWinPanel.text = Convert.ToString(StonesToWin);

            StartCoroutine(StonesInBasketEditing());
        }


        public int Calculate(char action, int value, string name)
        {
            var expectedAmount = CurrentAmountOfStones;
            if (action == '*') expectedAmount *= value;
            else if (action == '+') expectedAmount += value;
            else if (action == '-') expectedAmount -= value;
            else if (action == '/') expectedAmount /= value;


            if (name == "Ai") return expectedAmount;


            CurrentAmountOfStones = expectedAmount;
            StartCoroutine(StonesInBasketEditing());
            return CurrentAmountOfStones;
        }

        public void Calculate(GameButton button)
        {
            Calculate(button.Action, button.Value, "GameButtonOfPlayer");
        }

        public int Calculate(GameButton button, string name)
        {
            return Calculate(button.Action, button.Value, name);
        }

        public IEnumerator StonesInBasketEditing()
        {
            for (var j = int.Parse(currentAmountOfStonesPanel.text);;
            )
            {
                yield return new WaitForSeconds((float) 1 / (5 * Math.Abs(j - CurrentAmountOfStones)));
                if (j > CurrentAmountOfStones)
                {
                    j--;
                }

                if (j < CurrentAmountOfStones)
                {
                    j++;
                }

                StartCoroutine(BasketAnimation(1f, 1.2f));
                currentAmountOfStonesPanel.text = Convert.ToString(j);


                if (j != CurrentAmountOfStones) continue;
                GameplayStepsController.StepsController.IsVictory(StonesToWin == CurrentAmountOfStones);
                break;
            }

            StartCoroutine(BasketAnimation(1.2f, 1f));
        }

        private IEnumerator BasketAnimation(float startFloat, float endFloat)
        {
            for (var i = startFloat; Math.Abs(i - endFloat) > 0.01f; i += startFloat < endFloat ? 0.05f : -0.05f)
            {
                yield return new WaitForSeconds(1 / 20f);
                currentAmountOfStonesPanel.transform.localScale = new Vector3(i, i);
            }
        }
    }
}