using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class AI : MonoBehaviour
{
    private string choise;
    private int result;
    private GameButton ButtonRight, ButtonLeft;
    public int AiStep(GameButton ButtonLeft,GameButton ButtonRight, int res, int final)
    {
        

        switch (AiChoise(ButtonLeft.action, ButtonLeft.value, ButtonRight.action, ButtonRight.value, res, final))
        {
            case "Left":
                result = ButtonLeft.getResult(res);
                break;
            case "Right":
                result = ButtonRight.getResult(res);
                break;
        }
        
        return result;
    }
    private string AiChoise(char LeftAction, int LeftValue, char RightAction, int RightValue, int res, int final)
    {
        ButtonLeft = new GameButton();
        ButtonRight = new GameButton();
        ButtonLeft.SetGameButton(LeftAction, LeftValue);
        ButtonRight.SetGameButton(RightAction, RightValue);
        {
            if (Mathf.Abs(ButtonLeft.getResult(res) - final) < Mathf.Abs(ButtonRight.getResult(res) - final)&&(ButtonLeft.getResult(res)<final))
            {
                choise = "Left";
            }
            else if (Mathf.Abs(ButtonLeft.getResult(res) - final) > Mathf.Abs(ButtonRight.getResult(res) - final)&& (ButtonRight.getResult(res)<final))
            {
                choise = "Right";
            }
            return choise;

        }
    }
}
