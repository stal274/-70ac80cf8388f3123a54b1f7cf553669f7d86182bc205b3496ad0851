using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace GameScene
{
    public class Ai : MonoBehaviour
    {
        [NotNull] private string choice;
        [SerializeField] private GameButton[] gameButton;
        public Button[] buttonsAi;
        private Basket Basket;

        private void Start()
        {
            Basket = FindObjectOfType<Basket>();
        }

        public void AiStep()
        {
            
                StartCoroutine(AiChoice());
            

           
        }
        private void Update()
        {
            var stopgame = FindObjectOfType<GameplayStepsControl>().StopGame;
            if (stopgame)
            {
                StopAllCoroutines();
                return;
            }
        }
        private IEnumerator AiChoice()
        {

            yield return StartCoroutine(Basket.StonesInBasketGenerate());
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            choice =
            Mathf.Abs(Basket.Calculate(gameButton[0].Action, gameButton[0].Value, true) - Basket.StonesToWin) <=
            Mathf.Abs(Basket.Calculate(gameButton[1].Action, gameButton[1].Value, true) - Basket.StonesToWin)
                ? "Left"
                : "Right";

            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (choice == "Left" && buttonsAi[0].IsInteractable() ||
                choice == "Right" && !buttonsAi[1].IsInteractable())
            {
                Basket.Calculate(gameButton[0]);
            }
            else if (choice == "Right" && buttonsAi[1].IsInteractable() ||
                     choice == "Left" && !buttonsAi[0].IsInteractable())
            {
                Basket.Calculate(gameButton[1]);
            }

            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation



            foreach (var variable in gameButton)
            {
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                variable.GetComponent<Button>().interactable = true;
            }
            GameObject.Find("SFX_Tern_button_" + Random.Range(3, 5)).GetComponent<AudioSource>().Play();
            var pg = FindObjectOfType<GameplayStepsControl>();
            pg.WhoseTurn = "Human";
        }
    }
}