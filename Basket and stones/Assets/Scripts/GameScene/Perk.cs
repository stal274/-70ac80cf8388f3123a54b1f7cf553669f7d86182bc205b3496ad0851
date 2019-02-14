using System;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Perk
    {
        private string name;
        private readonly int cooldown;
        private Image sprite;
        public Perk(string name,int cooldown,Image sprite)
        {
            this.name = name;
            this.cooldown = cooldown;
            this.sprite = sprite;
        }

        private void PerkActivation()
        {
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