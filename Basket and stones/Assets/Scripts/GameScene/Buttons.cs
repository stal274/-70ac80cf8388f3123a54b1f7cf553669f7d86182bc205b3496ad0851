using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameScene
{
    public class Buttons : MonoBehaviour
    {
        public void Click(GameObject obj)
        {
            GameObject.Find("SFX_New_Game").GetComponent<AudioSource>().Play();
            switch (obj.name)
            {
                case "Retry_Button":
                    SceneManager.LoadScene("SinglePlayScene");
                    EventAggregator.EventAggregator.ButtonsActionsHaveChanged.Clear();
                    break;
                case "MainMenu_Button":
                    SceneManager.LoadScene("Main menu");
                    break;
                default:
                    Debug.LogWarning("Something wrong!");
                    break;
            }
        }
    }
}