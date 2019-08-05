using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainScene
{
    public class TimerToStartGame : MonoBehaviour
    {
        [SerializeField] private GameObject Timer;
        [SerializeField] private Text Text;

        public bool StartTick { private get; set; }

        private IEnumerator Tick()
        {
            for (var i = 5; i >= 0; i--)
            {
                Text.text = "0:0" + i;
                if (i == 0)
                {
                    new WaitForSeconds(0.5f);
                    SceneManager.LoadScene("TestGameScene");
                }

                yield return new WaitForSeconds(1f);
            }
        }

        // Update is called once per frame
        private void Start()
        {
            Timer = GameObject.Find("Timer");
            Text = Timer.GetComponent<Text>();
        }

        private void OnEnable()
        {
            StartTicker();
        }

        public void StartTicker()
        {
            if (StartTick)
            {
                StartCoroutine(Tick());
            }
            else
            {
                Text.text = "0:05";
                StopAllCoroutines();
            }
        }
    }
}