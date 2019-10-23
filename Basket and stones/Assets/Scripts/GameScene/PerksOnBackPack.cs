using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class PerksOnBackPack : MonoBehaviour
    {
        public static PerksOnBackPack Instance;

        [FormerlySerializedAs("PerksOnBackPackArray")]
        public List<Perk> perksOnBackPackArray;

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
                perksOnBackPackArray.Add(variable);
            }
        }

        public void CooldownOfPerks()
        {
            foreach (var variable in perksOnBackPackArray)
            {
                variable.Cooldown();
            }
        }
    }
}