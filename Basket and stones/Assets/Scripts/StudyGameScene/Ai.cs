using System.Collections;
using JetBrains.Annotations;
using StudyGameScene;
using UnityEngine;
using UnityEngine.UI;

namespace StudyGameScene
{
    public class Ai : MonoBehaviour
    {
        [NotNull] private string choice;
        private int i;
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

        public IEnumerator AiChoice()
        {
            if (FindObjectOfType<GameplayStepsControl>().StopGame) {yield return null; }
            yield return StartCoroutine(Basket.StonesInBasketGenerate());
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            if (i <=2)
            {
                Basket.Calculate(gameButton[0]);

            }
            
            i++;
            if (i > 2)
            {
                yield return null;
            }


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