using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MainScene
{
    public class BackpackProgressBar : MonoBehaviour
    {
        [FormerlySerializedAs("progressBar")] [SerializeField]
        private Image progressBarImage;

        [SerializeField] private float startFloat;
        private static BackpackProgressBar progressBar;

        private void Awake()
        {
            if (progressBar != null)
            {
            }

            progressBar = this;
        }

        private float EndFloat { get; set; }

        private void LoadingBackpack()
        {
            startFloat = gameObject.GetComponent<Image>().fillAmount;
            StartCoroutine(FillAmount());
        }

        private void OnBecameInvisible()
        {
            gameObject.GetComponent<Image>().fillAmount = 0;
        }

        private IEnumerator FillAmount()
        {
            for (var i = startFloat;
                Math.Abs(i - (EndFloat - 1 / 60f)) > 0.01;
                i += EndFloat - startFloat > 0 ? 1 / 60f : -1 / 60f)
            {
                yield return new WaitForSeconds(1 / 60f);
                if (Math.Abs(startFloat - EndFloat) < 0.0001f)
                {
                    break;
                }


                if (Math.Abs(i - (1f - 2 / 60f)) < 0.01f && Math.Abs(EndFloat - 1f) < 0.01)
                {
                    i = 1f;
                    progressBarImage.fillAmount = i;
                    break;
                }

                progressBarImage.fillAmount = i;
            }
        }

        public static void CheckBackPack()
        {
            var I = GameObject.FindGameObjectsWithTag("BackpackSlot")
                .Count(variable => variable.GetComponentsInChildren<Image>().Length >= 2);
            var timer = FindObjectOfType<TimerToStartGame>();
            timer.StartTick = I == 3;
            timer.StartTicker();
            switch (I)
            {
                case 0:
                    progressBar.EndFloat = 0f;
                    break;
                case 3:
                    progressBar.EndFloat = 1f;
                    for (var i = 0; i < GameObject.FindGameObjectsWithTag("BackpackSlot").Length; i++)
                    {
                        PlayerPrefs.SetString("BackpackSlot" + i,
                            GameObject.FindGameObjectsWithTag("BackpackSlot")[i].GetComponentInChildren<DragElement>()
                                .gameObject.name);
                    }

                    break;
                default:
                    progressBar.EndFloat = I / 3f;
                    break;
            }

            progressBar.LoadingBackpack();
            if (I != 0)
            {
                GameObject.Find("ProgressBarAudio").GetComponents<AudioSource>()[I - 1].Play();
            }
        }
    }
}