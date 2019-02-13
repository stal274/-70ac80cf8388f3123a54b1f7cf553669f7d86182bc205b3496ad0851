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

        public void PerkActivation()
        {
            
            Cooldown(cooldown);
        }

        private void Cooldown(int cooldown)
        {
          
        }
    }
}