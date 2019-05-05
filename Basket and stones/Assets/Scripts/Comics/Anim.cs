using UnityEngine;

namespace Comics
{
    public class Animation : MonoBehaviour
    {
        public void Awake()
        {
            GetComponent<UnityEngine.Animation>().Play();
        }
    }
}