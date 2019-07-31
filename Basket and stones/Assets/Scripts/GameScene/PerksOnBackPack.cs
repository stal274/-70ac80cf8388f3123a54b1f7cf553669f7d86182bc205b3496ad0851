using UnityEngine;

namespace GameScene
{
    public class PerksOnBackPack : MonoBehaviour
    {
        [SerializeField] private Perk[] perks = new Perk[3];

        private void Start()
        {
            for (var i = 0; i < perks.Length; i++)
            {
                perks[i] = gameObject.GetComponentsInChildren<Perk>()[i];
            }
        }

        public void CooldownOfPerks()
        {
            foreach (var VARIABLE in perks)
            {
                VARIABLE.Cooldown();
            }
        }
    }
}