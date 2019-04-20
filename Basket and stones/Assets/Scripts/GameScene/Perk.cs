using System;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Perk
    {
        private string name;
        private readonly int cooldown;
        private Image sprite;
        private bool IsActive = true;

        public Perk(string name, int cooldown, Image sprite)
        {
            this.name = name;
            this.cooldown = cooldown;
            this.sprite = sprite;
        }

        private void PerkActivation()
        {
            /*switch (name)
            {
                case 
            }*/
            //Активация перков через Switch-case
            IsActive = !IsActive;
        }

        private void Cooldown(int cooldown)
        {
        }

        public void OnClick()
        {
            if (IsActive)
            {
                PerkActivation();
            }
        }
    }
}