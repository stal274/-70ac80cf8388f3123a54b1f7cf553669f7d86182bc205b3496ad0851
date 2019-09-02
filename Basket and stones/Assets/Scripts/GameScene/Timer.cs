using UnityEngine;
using UnityEngine.UI;

namespace GameScene
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float coolTimer;

        public Text timer;

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            minusSecond();
        }

        private void minusSecond()
        {
            coolTimer -= Time.deltaTime;
            if (coolTimer > 0)
            {
                timer.text = Mathf.RoundToInt(coolTimer).ToString();
            }
        }
    }
}