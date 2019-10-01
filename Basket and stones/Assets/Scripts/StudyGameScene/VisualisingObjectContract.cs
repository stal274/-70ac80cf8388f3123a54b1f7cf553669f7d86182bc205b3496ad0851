using System.Collections;
using UnityEngine;

namespace StudyGameScene
{
    public class VisualisingObjectContract : MonoBehaviour
    {
        private GameObject _obj;

        public void ObjectVisibleAfter1Second(GameObject obj)
        {
            this._obj = obj;
            this._obj.SetActive(false);

            StartCoroutine(CheckingAnimations());
        }

        private IEnumerator CheckingAnimations()
        {
            if (FindObjectOfType<GameplayStepsControl>().StopGame)
            {
                yield return null;
            }

            var basket = GameObject.FindObjectOfType<Basket>();
            yield return StartCoroutine(basket.StonesInBasketGenerate());

            yield return new WaitForSeconds(2f);
            _obj.SetActive(true);
        }
    }
}