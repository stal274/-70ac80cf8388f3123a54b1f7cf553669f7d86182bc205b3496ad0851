
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject SettingAction;
    public GameObject MainAction;
    
    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Exit":
                
                break;
            case "StartGame_Button":
                SceneManager.LoadScene("TestGameScene");
                break;
            case "Settings_Button":
                SettingAction.SetActive(true);
            MainAction.SetActive(false);
                break;
            default:
                break;
        }
    }
}