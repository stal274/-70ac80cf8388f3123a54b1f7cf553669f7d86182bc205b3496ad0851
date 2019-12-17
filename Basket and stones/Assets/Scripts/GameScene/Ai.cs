using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameScene
{
    public class Ai : Player
    {
        private int _choice;


        public static Ai Instance;

        private void Start()
        {
            if (IsInitialiseInstance()) return;
            _perksList = FindObjectsOfType<Perk>().Select(variable => variable).ToList();
            _name = "Computer";
            foreach (var variable in gameObject.GetComponent<Human>().gameButton)
            {
                gameButton.Add(variable);
            }

            EventAggregator.EventAggregator.GameIsOver.Subscribe(GameIsOver);
        }

        private void GameIsOver(object obj)
        {
            StopAllCoroutines();
        }

        private bool IsInitialiseInstance()
        {
            if (Instance != null)
            {
                Debug.LogWarning("Error");
                return true;
            }

            Instance = this;
            return false;
        }

        public void AiStep()
        {
            StartCoroutine(ChooseTheMostWinningMove());
        }


        private IEnumerator ChooseTheMostWinningMove()
        {
            yield return StartCoroutine(Basket.Instance.StonesInBasketEditing(1f, 1.2f));
            var resultArray = gameButton.Where(x => x.intractable)
                .Select(x => Math.Abs(Basket.Instance.Calculate(x) - Basket.Instance.StonesToWin)).ToList();
            _choice = resultArray.IndexOf(resultArray.Concat(new[] {int.MaxValue}).Min());
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            GameButtonActivation();
        }


        public override void GameButtonActivation()
        {
            gameButton[_choice].OnClick();
            EventAggregator.EventAggregator.MoveComplete.Publish(this);
        }

        internal override void PerkActivation()
        {
        }
    }
}