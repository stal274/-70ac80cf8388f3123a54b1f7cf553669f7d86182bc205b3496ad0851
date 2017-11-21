using System.Collections;
using UnityEngine;



public class MainButtons : MonoBehaviour
{
  

    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Exit":
                Application.Quit();
                break;

        }
    }
    
    


}
