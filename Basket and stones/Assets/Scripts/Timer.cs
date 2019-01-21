using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float coolTimer;

    public Text timer;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        minusSecond();
    }

    void minusSecond()
    {
        coolTimer -= Time.deltaTime;

        if (coolTimer > 0)
        {
            timer.text = Mathf.RoundToInt(coolTimer).ToString();
        }
    }
}