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
                /*MainAction.SetActive(false);
                SettingAction.SetActive(true);*/
                Application.LoadLevel(1);
                break;
        }
    }
}