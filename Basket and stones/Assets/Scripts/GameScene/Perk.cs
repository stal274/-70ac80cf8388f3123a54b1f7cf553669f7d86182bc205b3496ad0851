using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameScene
{
    public class Perk : MonoBehaviour
    {
        public string perkName;
        [SerializeField] private int cooldown, progressOfcooldown, stepsIsWork;
        [SerializeField] private int stepsIsWorkTick;
        [SerializeField] private Image image;
        [SerializeField] private bool IsActive = true;
        [SerializeField] private GameButton[] GameButton;

        private void Awake()
        {
            perkName = gameObject.name;
            image = gameObject.GetComponent<Image>();
            stepsIsWorkTick = stepsIsWork;
            GameButton = FindObjectsOfType<GameButton>();
        }

        private void PerkActivation()
        {
            if (GameplayStepsControl.stepsControl.WhoseTurn == "Computer")
            {
                return;
            }

            image.fillAmount = 0f;
            switch (perkName)
            {
                case "Frost":

                    Ai.ai.buttonsAi[Random.Range(0, 2)].interactable = false;
                    break;
                case "Shake":

                    var inti = Random.Range(1, 11);
                    while (Basket.basket.CurrentAmountOfStones - inti <= 0)
                    {
                        inti = Random.Range(1, 11);
                    }

                    Basket.basket.Calculate('-', inti, false);
                    break;
                case "Replacement":
                    var bank = FindObjectOfType<SafeDepositOfButtonActions>();
                    bank.GenerateIndex();

                    break;
            }

            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }

            if (IsActive)
            {
                IsActive = !IsActive;
            }
        }

        private IEnumerator FillAmount()
        {
            for (var i = image.fillAmount;
                Math.Abs(i - (float)progressOfcooldown / cooldown) >
                (float)1 / (60 * cooldown);
                i +=
                    (float)1 / (60 * cooldown))
            {
                yield return new WaitForSeconds((float)1 / (60 * cooldown));
                image.fillAmount = i;
                if (!(Math.Abs(i - (1f - (float)1 / (60 * cooldown))) < (float)1 / (60 * cooldown)))
                {
                    continue;
                }

                image.fillAmount = 1f;
                break;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (image.fillAmount != 1f)
            {
                yield break;
            }

            IsActive = !IsActive;
            progressOfcooldown = 0;
        }

        public void Cooldown()
        {
            if (IsActive)
            {
                return;
            }

            CheckOfWork();
            if (progressOfcooldown != cooldown)
            {
                progressOfcooldown++;
            }

            StartCoroutine(FillAmount());
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

            if (stepsIsWorkTick != 0 || gameObject.name != "Frost")
            {
                return;
            }

            foreach (var VARIABLE in Ai.ai.buttonsAi)
            {
                VARIABLE.interactable = true;
            }
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