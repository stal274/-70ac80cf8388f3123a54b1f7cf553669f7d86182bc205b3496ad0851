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
        private readonly byte Difficulty = MainMenu.Difficulty;
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
            var i = 0;
            if (Difficulty == 0)
                i = Random.Range(10, 26);
            else if (Difficulty == 1)
                i = Random.Range(15, 47);
            else if (Difficulty == 2) i = Random.Range(47, 81);
            CurrentAmountOfStones = i;
            StartCoroutine(StonesInBasketGenerate());
            StonesToWin = Random.Range(i + i * 3, i + i * 5);
            stonesToWinPanel.text = Convert.ToString(StonesToWin);
        }


        public int Calculate(char action, int value, bool isAi)
        {
            var expectedAmount = CurrentAmountOfStones;
            if (action == '*')
                expectedAmount *= value;
            else if (action == '+')
                expectedAmount += value;
            else if (action == '-')
                expectedAmount -= value;
            else if (action == '/') expectedAmount /= value;
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

        private void StonesInBasketGenerate(int i)
        {
            currentAmountOfStones = i;
            currentAmountOfStonesPanel.text = Convert.ToString(currentAmountOfStones);
        }
    }
}