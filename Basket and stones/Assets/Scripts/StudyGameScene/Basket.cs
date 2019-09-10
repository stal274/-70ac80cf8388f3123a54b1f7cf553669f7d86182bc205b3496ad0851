using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace StudyGameScene
{
    public class Basket : MonoBehaviour
    {
        [SerializeField] private Text currentAmountOfStonesPanel, stonesToWinPanel;
        [SerializeField] private int currentAmountOfStones;
        public int StonesToWin { get; private set; }

        public int CurrentAmountOfStones
        {
            get { return currentAmountOfStones; }
            private set { currentAmountOfStones = value; }
        }

        private void Start()
        {

            CurrentAmountOfStones = int.Parse(GameObject.Find("StonesInBasket_Text").GetComponent<Text>().text);
            StonesToWin = int.Parse(stonesToWinPanel.text);


            StartCoroutine(StonesInBasketGenerate());


        }


        public int Calculate(char action, int value, bool isAi)
        {

            var expectedAmount = CurrentAmountOfStones;
            if (action == '*')
            {
                expectedAmount *= value;
            }
            else if (action == '+')
            {
                expectedAmount += value;
            }
            else if (action == '-')
            {
                expectedAmount -= value;
            }
            else if (action == '/')
            {
                expectedAmount /= value;
            }

            if (isAi)
            {
                return expectedAmount;
            }

            CurrentAmountOfStones = expectedAmount;
            StartCoroutine(StonesInBasketGenerate());
            return CurrentAmountOfStones;
        }

        public void Calculate(GameButton button)
        {
            Calculate(button.Action, button.Value, false);
            
        }

        public IEnumerator StonesInBasketGenerate()
        {
            for (var j = int.Parse(currentAmountOfStonesPanel.text); ;
            )
            {
                yield return new WaitForSeconds((float)1 / (5 * Math.Abs(j - CurrentAmountOfStones)));
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


                if (j == CurrentAmountOfStones)
                {
                    break;
                }
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