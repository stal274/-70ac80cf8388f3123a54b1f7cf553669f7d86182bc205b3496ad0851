using UnityEngine;

namespace Player
{
    public class Wallet : MonoBehaviour
    {
        public int FireCoins
        {
            get { return PlayerPrefs.GetInt("FireCoins"); }
            set
            {
                fireCoins = value;
                PlayerPrefs.SetInt("FireCoins", fireCoins);
            }
        }

        private int fireCoins;
        public int FireCrystals { get; private set; }
    }
}