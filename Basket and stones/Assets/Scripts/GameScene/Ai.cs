using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameScene
{
    public class Ai : MonoBehaviour
    {
        [SerializeField] private int _choice;
        [SerializeField] private GameButton[] gameButton;
        public Button[] buttonsAi;
        public string DebuffName { private get; set; }
        public static Ai Computer;

        private void Awake()
        {
            if (Computer != null)
            {
                Debug.LogWarning("Error");
                return;
            }

            EventAggregator.GameIsOver.Subscribe(StopPlay);

            Computer = this;
        }

        public void AiStep()
        {
            StartCoroutine(AiChoice());
        }

        private void StopPlay(Basket basket)
        {
            StopAllCoroutines();
        }

        private IEnumerator AiChoice()
        {
            yield return StartCoroutine(Basket.Instance.StonesInBasketEditing(1f, 1.2f));
            if (Instance.DebuffName == "Stun")
            {
                yield return new WaitForSeconds(0.8f);
                RestorePlayerButtons();
                yield break;
            }

            var resultArray = gameButton
                .Select(variable => Math.Abs(Basket.Instance.Calculate(variable, "Ai") - Basket.Instance.StonesToWin))
                .ToList();
            _choice = resultArray.IndexOf(Math.Min(resultArray[0], resultArray[1]));
            if (!buttonsAi[_choice].interactable)
            {
                var intractableArray = buttonsAi.Select(variable => variable.interactable).ToList();
                _choice = intractableArray.IndexOf(true);
            }

            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            Basket.Instance.Calculate(gameButton[_choice]);
            RestorePlayerButtons();
        }

        private void RestorePlayerButtons()
        {
            foreach (var variable in gameButton)
            {
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                variable.GetComponent<Button>().interactable = true;
            }

            GameObject.Find("SFX_Tern_button_" + Random.Range(3, 5)).GetComponent<AudioSource>().Play();
            GameplayStepsController.Instance.WhoseTurn = "Human";
        }
    }
}