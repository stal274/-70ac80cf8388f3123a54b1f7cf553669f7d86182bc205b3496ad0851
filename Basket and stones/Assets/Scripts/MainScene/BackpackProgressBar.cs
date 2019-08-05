using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene
{
    public class BackpackProgressBar : MonoBehaviour
    {
        [SerializeField] private Image progressBar;
        [SerializeField] private float startFloat;


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
                    progressBar.fillAmount = i;
                    break;
                }

                progressBar.fillAmount = i;
            }
        }

        public static void CheckBackPack()
        {
            var I = 0;
            for (var i = 0; i < GameObject.FindGameObjectsWithTag("BackpackSlot").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("BackpackSlot")[i].GetComponentsInChildren<Image>().Length == 2)
                {
                    I++;
                }
            }

            var script = FindObjectOfType<BackpackProgressBar>();
            var timer = FindObjectOfType<TimerToStartGame>();
            timer.StartTick = I == 3;
            timer.StartTicker();
            switch (I)
            {
                case 0:
                    script.EndFloat = 0f;
                    break;
                case 3:
                    script.EndFloat = 1f;
                    for (var i = 0; i < GameObject.FindGameObjectsWithTag("BackpackSlot").Length; i++)
                    {
                        PlayerPrefs.SetString("BackpackSlot" + i,
                            GameObject.FindGameObjectsWithTag("BackpackSlot")[i].GetComponentInChildren<DragElement>()
                                .gameObject.name);
                    }

                    break;
                default:
                    script.EndFloat = I / 3f;
                    break;
            }

            script.LoadingBackpack();
            if (I != 0)
            {
                GameObject.Find("ProgressBarAudio").GetComponents<AudioSource>()[I - 1].Play();
            }
        }
    }
}