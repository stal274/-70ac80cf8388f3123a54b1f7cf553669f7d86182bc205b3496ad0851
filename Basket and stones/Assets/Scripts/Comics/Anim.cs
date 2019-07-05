using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Comics
{
    public class Anim : MonoBehaviour
    {
        private static int i;
        private static string sprite = "Sprite_" + i;

        public void Awake()
        {
            GameObject.Find(sprite).GetComponent<UnityEngine.Animation>().Play();
            Invoke("AnimPlay", 3);
            Invoke("AnimPlay", 5);
        }

        private static void AnimPlay()
        {
            i++;
            sprite = "Sprite_" + i;
            GameObject.Find(sprite).GetComponent<UnityEngine.Animation>()
                .Play();
        }

        /*private void Start()
        {
            if (PlayerPrefs.GetInt("FirstStart") == 1)
            {
                SceneManager.LoadScene("Main menu");
                PlayerPrefs.SetInt("FirstStart", 0);
            }
        }*/
    }
}