using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameScene
{
    public class Perk : MonoBehaviour
    {
        public string perkName;
        [SerializeField] private int cooldown, skillIsValidFor;
        private int _skillProgress, _progressOfcooldown;
        [SerializeField] private Image image;

        [FormerlySerializedAs("IsActive")] [SerializeField]
        private bool isActive = true;

        private void Awake()
        {
            perkName = gameObject.name;
            image = gameObject.GetComponent<Image>();
            _skillProgress = skillIsValidFor;
        }

        public void PerkActivation()
        {
            if (GameplayStepsController.StepsController.WhoseTurn == "Computer") return;
            switch (perkName)
            {
                case "Frost":

                    Ai.Computer.buttonsAi[Random.Range(0, 2)].interactable = false;
                    break;
                case "Shake":

                    var inti = Random.Range(1, 11);
                    while (Basket.basket.CurrentAmountOfStones - inti <= 0)
                    {
                        inti = Random.Range(1, 11);
                    }

                    Basket.basket.Calculate('-', inti, "Basket");
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

                    cooldown = Convert.ToInt32(cooldown / 0.66);
                    break;
                case "Pipe":
                    Debug.Log(perkName);
                    Ai.Computer.DebuffName = "Stun";
                    break;
                default:
                    Debug.LogWarning("Something wrong!");
                    break;
            }

            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }

            image.fillAmount = 0f;
            if (isActive)
            {
                isActive = false;
            }
        }

        private void PerkDeactivation()
        {
            switch (perkName)
            {
                case "Frost":
                    foreach (var VARIABLE in Ai.Computer.buttonsAi)
                    {
                        VARIABLE.interactable = true;
                    }

                    break;
                case "Coffee":

                    foreach (var perks in PerksOnBackPack.Instance.PerksOnBackPackArray)
                    {
                        perks.cooldown = Convert.ToInt32(perks.cooldown / 0.66);
                    }

                    cooldown = Convert.ToInt32(cooldown * 0.66);
                    break;
                case "Pipe":
                    Ai.Computer.DebuffName = null;
                    break;
            }
        }

        private IEnumerator FillAmount()
        {
            for (var i = image.fillAmount;
                Math.Abs(i - (float) _progressOfcooldown / cooldown) >
                (float) 1 / (60 * cooldown);
                i +=
                    (float) 1 / (60 * cooldown))
            {
                yield return new WaitForSeconds((float) 1 / (60 * cooldown));
                image.fillAmount = i;
                if (!(Math.Abs(i - (1f - (float) 1 / (60 * cooldown))) < (float) 1 / (60 * cooldown)))
                {
                    continue;
                }

                image.fillAmount = 1f;
                break;
            }


            if (image.fillAmount != 1f) yield break;


            isActive = !isActive;
            _progressOfcooldown = 0;
        }

        public void Cooldown()
        {
            if (isActive) return;
            CheckOfWork();
            if (_progressOfcooldown != cooldown)
            {
                _progressOfcooldown++;
            }

            StartCoroutine(FillAmount());
        }

        private void CheckOfWork()
        {
            if (_skillProgress > 0)
            {
                _skillProgress--;
            }
            else if (_skillProgress == 0)
            {
                _skillProgress = skillIsValidFor;
                PerkDeactivation();
            }
        }
    }
}