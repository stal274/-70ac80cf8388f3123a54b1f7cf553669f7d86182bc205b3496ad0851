using System.Linq;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private GameObject[] audioArray;

    private void Start()
    {
        audioArray = GameObject.FindGameObjectsWithTag("GameAudio");
        if (gameObject.CompareTag("Audio"))
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (!gameObject.CompareTag("GameAudio") || audioArray.Length > 1)
        {
            Destroy(audioArray.Last());
        }
    }
}