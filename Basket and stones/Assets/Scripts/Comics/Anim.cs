using System;
using UnityEngine;
using UnityEngine.UI;

namespace Comics
{
    public class Anim : MonoBehaviour
    {
        private String sprite = "Sprite_1";

        public void Awake()
        {
            GameObject.Find("Sprite_0").GetComponent<UnityEngine.Animation>().Play();
            Invoke("AnimPlay", 2);
        }

        private void AnimPlay()
        {
            GameObject.Find(sprite).GetComponent<UnityEngine.Animation>()
                .PlayQueued(
                    "Comics", QueueMode.CompleteOthers);
        }
    }
}