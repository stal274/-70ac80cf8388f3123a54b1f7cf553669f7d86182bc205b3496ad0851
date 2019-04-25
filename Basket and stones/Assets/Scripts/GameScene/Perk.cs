using System;
using System.Diagnostics;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Perk : PlayingGame
    {
        public string name;
        public readonly int cooldown;
        public Image sprite;
        private bool IsActive;
        public Button Perk0;

        public Perk(string name, int cooldown, Image sprite)
        {
            this.name = name;
            this.cooldown = cooldown;
            this.sprite = sprite;
        }

        private void PerkActivation()
        {
            switch (name)
            {
                case "Заморозка":
                    int i = 0;
                    i = Random.Range(0, 2);
                    switch (i)

                    {
                        case 0:
                            ButtonLeft.interactable = false;
                            break;
                        case 1:
                            ButtonRight.interactable = false;
                            break;
                    }

                    print(name);
                    break;
                case "Встряска":
                    var inti = Random.Range(1, 11);
                    while (StonesInBasket - inti <= 0)
                    {
                        inti = Random.Range(1, 11);
                    }

                    StonesInBasket -= inti;

                    StonesInBasketUpdate();
                    break;
                case "Подмена":
                    print(name);
                    ButtonsValueGenerate();

                    break;
            }

            if (IsActive)
            {
                IsActive = !IsActive;
            }
        }

        private void Cooldown(int cooldown)
        {
        }

        public void PerkOnClick()
        {
            if (!IsActive)
            {
                PerkActivation();
            }

            Perk0.interactable = false;
        }
    }
}