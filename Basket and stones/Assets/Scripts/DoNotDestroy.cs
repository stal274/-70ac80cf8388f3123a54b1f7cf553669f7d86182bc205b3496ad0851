using System.Linq;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private GameObject[] AudioArray;

    private void Start()
    {
        AudioArray = GameObject.FindGameObjectsWithTag("GameAudio");
        if (gameObject.CompareTag("Audio"))
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (!gameObject.CompareTag("GameAudio") || AudioArray.Length > 1)
        {
            Destroy(AudioArray.Last());
        }
    }
}