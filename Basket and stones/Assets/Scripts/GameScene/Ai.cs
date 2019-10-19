using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameScene
{
    public class Ai : MonoBehaviour
    {
        private string _choice;
        [SerializeField] private GameButton[] gameButton;
        public Button[] buttonsAi;

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

        private void Start()
        {
            Basket.basket = FindObjectOfType<Basket>();
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
            yield return StartCoroutine(Basket.basket.StonesInBasketEditing());
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            Basket.basket.Calculate(gameButton[_choice]);
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
            GameplayStepsController.StepsController.WhoseTurn = "Human";
        }
    }
}