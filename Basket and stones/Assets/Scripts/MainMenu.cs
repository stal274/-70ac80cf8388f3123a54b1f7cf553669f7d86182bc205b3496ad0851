using System.Collections;
using UnityEngine;


public class MainButtons : MonoBehaviour
{
    public GameObject SettingAction;
    public GameObject MainAction;

    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Exit":
                Application.Quit();
                break;
            case "StartGame_Button":
                Application.LoadLevel(1);
                break;
            case "Settings_Button":
                break;
        }
    }
}