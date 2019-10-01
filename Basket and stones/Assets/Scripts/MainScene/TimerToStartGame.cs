using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MainScene
{
    public class TimerToStartGame : MonoBehaviour
    {

        [FormerlySerializedAs("Text")] [SerializeField] private Text text;

        public bool StartTick { private get; set; }

        private IEnumerator Tick()
        {
            for (var i = 5; i >= 0; i--)
            {
                text.text = "0:0" + i;
                if (i == 0)
                {
                    new WaitForSeconds(0.5f);
                    SceneManager.LoadScene("TestGameScene");
                }

                yield return new WaitForSeconds(1f);
            }
        }

    
        private void Start()
        {
            var timer = GameObject.Find("Timer");
            text = timer.GetComponent<Text>();
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
                text.text = "0:05";
                StopAllCoroutines();
            }
        }
    }
}