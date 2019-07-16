using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Start()
    {
        if (gameObject.CompareTag("Audio"))
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}