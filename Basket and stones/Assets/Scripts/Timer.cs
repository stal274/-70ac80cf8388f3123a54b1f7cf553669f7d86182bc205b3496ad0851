using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float coolTimer;
    public Text timer;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
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