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

        private void Update()
        {
            if (!GameplayStepsController.StepsController.StopGame) return;
            StopAllCoroutines();
        }

        private IEnumerator AiChoice()
        {
            yield return StartCoroutine(Basket.basket.StonesInBasketEditing());
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            _choice =
                Mathf.Abs(Basket.basket.Calculate(gameButton[0], "Ai") -
                          Basket.basket.StonesToWin) <=
                Mathf.Abs(Basket.basket.Calculate(gameButton[1], "Ai") -
                          Basket.basket.StonesToWin)
                    ? "Left"
                    : "Right";

            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (_choice == "Left" && buttonsAi[0].IsInteractable() ||
                _choice == "Right" && !buttonsAi[1].IsInteractable())
            {
                Basket.basket.Calculate(gameButton[0]);
            }
            else if (_choice == "Right" && buttonsAi[1].IsInteractable() ||
                     _choice == "Left" && !buttonsAi[0].IsInteractable())
            {
                Basket.basket.Calculate(gameButton[1]);
            }

            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation


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