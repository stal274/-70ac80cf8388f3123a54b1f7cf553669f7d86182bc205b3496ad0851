using UnityEngine;
using UnityEngine.UI;

public class FireCoinsIndicator : MonoBehaviour
{
    private Text fireCoinsText;
    public static FireCoinsIndicator fireCoins;
    private void Awake()
    {
        if (fireCoins != null)
        {
            return;
        }
        fireCoins = this;
        fireCoinsText = GameObject.Find("FireCoin_Value").GetComponent<Text>();
    }
    private void Start()
    {
        CoinsValueUpdate();   
    }
    public void CoinsValueUpdate()
    {
        fireCoinsText.text = System.Convert.ToString(Player.Wallet.wallet.FireCoins);
    }
}
