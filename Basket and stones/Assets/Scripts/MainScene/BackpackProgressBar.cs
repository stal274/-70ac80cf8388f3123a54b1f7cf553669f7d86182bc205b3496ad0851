using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackpackProgressBar : MonoBehaviour
{
    private Image ProgressBar;
    private float StartFloat;

    public float EndFloat { private get; set; }

    public void LoadingBackpack()
    {
        StartFloat = gameObject.GetComponent<Image>().fillAmount;
        StartCoroutine(fillAmount());
    }

    private void Start()
    {
        StartFloat = gameObject.GetComponent<Image>().fillAmount;
        ProgressBar = gameObject.GetComponent<Image>();
    }


    IEnumerator fillAmount()
    {
        for (var i = StartFloat;
            Math.Abs(i - (EndFloat - 1 / 60f)) > 0.01;
            i += EndFloat - StartFloat > 0 ? 1 / 60f : -1 / 60f)
        {
            if (Math.Abs(StartFloat - EndFloat) < 0.0001f)
            {
                break;
            }


            yield return new WaitForSeconds(1 / 60f);
            if (Math.Abs(i - (1f - 2 / 60f)) < 0.01f && Math.Abs(EndFloat - 1f) < 0.01)
            {
                i = 1f;
                ProgressBar.fillAmount = i;
                break;
            }

            ProgressBar.fillAmount = i;
        }
    }
}