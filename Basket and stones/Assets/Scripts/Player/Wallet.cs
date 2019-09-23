using UnityEngine;

namespace Player
{
    public class Wallet : MonoBehaviour
    {
        public static Wallet wallet;
      
        public int FireCoins
        {
            get { return fireCoins; }
            set
            {
                fireCoins = value;
                PlayerPrefs.SetInt("FireCoins", fireCoins);
                FireCoinsIndicator.fireCoins.CoinsValueUpdate();
            }
        }

        private int fireCoins;
        public int FireCrystals { get; private set; }
        private void Awake()
        {
            if (wallet != null)
            {
                Debug.LogWarning("Error in wallet!");
                return;
            }
            wallet = this;
            
        }
        private void Start()
        {
            FireCoins = PlayerPrefs.GetInt("FireCoins");
            ZeroCheck();
        }
        private void ZeroCheck()
        {
            
        }
    }
}