using System;
using System.Collections;
using StudyGameScene;
using UnityEngine;
using UnityEngine.UI;

namespace StudyGameScene
{
    public class Perk : MonoBehaviour
    {
        public string perkName;
        [SerializeField] private int cooldown, progressOfcooldown, stepsIsWork;
        [SerializeField] private int stepsIsWorkTick;
        [SerializeField] private Image image;
        [SerializeField] private bool IsActive = true;
        [SerializeField] private Ai ai;
        [SerializeField] private GameButton[] GameButton;
        [SerializeField] private Basket basket;

        private void Start()
        {
            perkName = gameObject.name;
            image = gameObject.GetComponent<Image>();
            ai = FindObjectOfType<Ai>();
            stepsIsWorkTick = stepsIsWork;
            GameButton = FindObjectsOfType<GameButton>();
            basket = FindObjectOfType<Basket>();
        }

        private void PerkActivation()
        {
            var pg = FindObjectOfType<GameplayStepsControl>();
            if (pg.WhoseTurn == "Computer")
            {
                return;
            }

            image.fillAmount = 0f;
            switch (perkName)
            {
                case "Shake":


                    basket.Calculate('-', 5, false);
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
                Math.Abs(i - (float) progressOfcooldown / cooldown) >
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

            foreach (var VARIABLE in ai.buttonsAi)
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