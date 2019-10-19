using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class PerksOnBackPack : MonoBehaviour
    {
        public static PerksOnBackPack Instance;

        public List<Perk> PerksOnBackPackArray;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("Error!");
            }

            Instance = this;
        }

        private void Start()
        {
            var perksOnBackpackArray = gameObject.GetComponentsInChildren<Perk>();
            foreach (var variable in perksOnBackpackArray)
            {
                PerksOnBackPackArray.Add(variable);
            }
        }

        public void CooldownOfPerks()
        {
            foreach (var variable in PerksOnBackPackArray)
            {
                variable.Cooldown();
            }
        }
    }
}