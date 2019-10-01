using UnityEngine;

namespace GameScene
{
    public class PerksOnBackPack : MonoBehaviour
    {
        private Perk[] _perksOnBackPackArray = new Perk[3];
        public static PerksOnBackPack Instance;

        public Perk[] PerksOnBackPackArray
        {
            get { return _perksOnBackPackArray; }

            set { _perksOnBackPackArray = value; }
        }

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
            var perksOnBackPackArray = gameObject.GetComponentsInChildren<Perk>();
            for (int i = 0; i < PerksOnBackPackArray.Length; i++)
            {
                PerksOnBackPackArray[i] = perksOnBackPackArray[i];
            }
        }

        public void CooldownOfPerks()
        {
            foreach (var VARIABLE in PerksOnBackPackArray)
            {
                VARIABLE.Cooldown();
            }
        }
    }
}