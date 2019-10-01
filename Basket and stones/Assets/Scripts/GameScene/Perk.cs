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
        [SerializeField] private int cooldown, skillIsValidFor;
        private int skillProgress, progressOfcooldown;
        [SerializeField] private Image image;
        [SerializeField] private bool IsActive = true;

        private void Awake()
        {
            perkName = gameObject.name;
            image = gameObject.GetComponent<Image>();
            skillProgress = skillIsValidFor;
           
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
                case "Coffee":

                    foreach (var perks in PerksOnBackPack.Instance.PerksOnBackPackArray)
                    {
                        perks.cooldown = Convert.ToInt32(perks.cooldown * 0.66);
                    }
                    this.cooldown = Convert.ToInt32(cooldown / 0.66);
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
        private void PerkDeactivation()
        {
            switch (perkName)
            {
                case "Frost":
                    foreach (var VARIABLE in Ai.ai.buttonsAi)
                    {
                        VARIABLE.interactable = true;
                    }
                    break;
                case "Coffee":

                    foreach (var perks in PerksOnBackPack.Instance.PerksOnBackPackArray)
                    {
                        perks.cooldown = Convert.ToInt32(perks.cooldown / 0.66);
                    }
                    this.cooldown = Convert.ToInt32(cooldown * 0.66);
                    break;
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
            if (skillProgress > 0)
            {
                skillProgress--;
            }
            else if (skillProgress == 0)
            {
                skillProgress = skillIsValidFor;
                PerkDeactivation();

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