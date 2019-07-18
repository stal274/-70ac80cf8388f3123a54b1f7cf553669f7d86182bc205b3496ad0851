using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameScene
{
    public class Perk : MonoBehaviour
    {
        public string name;
        [SerializeField] private int cooldown, progressOfcooldown, stepsIsWork;
        [SerializeField] private int stepsIsWorkTick;
        [SerializeField] private Image image;
        [SerializeField] private bool IsActive = true;
        [SerializeField] private Ai AI;
        [SerializeField] private PlayingGame PG;

        private void Start()
        {
            name = gameObject.name;
            image = gameObject.GetComponent<Image>();
            AI = FindObjectOfType<Ai>();
            stepsIsWorkTick = stepsIsWork;
        }

        private void PerkActivation()
        {
            image.fillAmount = 0f;
            switch (name)
            {
                case "Frost":
                    int i;
                    i = Random.Range(0, 2);
                    switch (i)

                    {
                        case 0:
                            AI.ButtonLeft.interactable = false;
                            break;
                        case 1:
                            AI.ButtonRight.interactable = false;
                            break;
                    }


                    break;
                case "Shake":
                    var inti = Random.Range(1, 11);
                    while (PG.StonesInBasket - inti <= 0)
                    {
                        inti = Random.Range(1, 11);
                    }

                    PG.StonesInBasket -= inti;

                    PG.StonesInBasketUpdate();
                    break;
                case "Replacement":

                    PG.ButtonsValueGenerate();

                    break;
            }

            if (IsActive)
            {
                IsActive = !IsActive;
            }
        }

        IEnumerator fillAmount()
        {
            for (var i = image.fillAmount;
                Math.Abs(i - (float) progressOfcooldown / cooldown) >
                (float) 1 / (60 * cooldown);
                i +=
                    (float) 1 / (60 * cooldown))
            {
                yield return new WaitForSeconds((float) 1 / (60 * cooldown));
                image.fillAmount = i;
                if (!(Math.Abs(i - (1f - (float) 1 / (60 * cooldown))) < (float) 1 / (60 * cooldown))) continue;
                image.fillAmount = 1f;
                break;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (image.fillAmount != 1f) yield break;
            IsActive = !IsActive;
            progressOfcooldown = 0;
        }

        public void Cooldown()
        {
            if (IsActive) return;
            CheckOfWork();
            if (progressOfcooldown != cooldown)
            {
                progressOfcooldown++;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
          

            StartCoroutine(fillAmount());
        }

        private void CheckOfWork()
        {
            if (stepsIsWorkTick > 0)
            {
                stepsIsWorkTick--;
            }
            else if (stepsIsWorkTick == 0)
            {
                stepsIsWorkTick = stepsIsWork;
            }

            if (stepsIsWorkTick != 0 || gameObject.name != "Frost") return;
            AI.ButtonLeft.interactable = true;
            AI.ButtonRight.interactable = true;
        }

        public void PerkOnClick()
        {
            if (IsActive)
            {
                PerkActivation();
            }
        }
    }
}