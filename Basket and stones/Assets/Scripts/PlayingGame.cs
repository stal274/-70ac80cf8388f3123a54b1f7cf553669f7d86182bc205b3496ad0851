using UnityEngine;
using UnityEngine.UI;

public class PlayingGame : MonoBehaviour
{
    public Button ButtonLeft, ButtonRight;
    public Text ResultPanel;
    private GameButton GameButtonLeft, GameButtonRight;
    private AI computer;
    private int[] ButtonLeftActionNumericalValue = new int[] {3, 2, 2};
    private int[] ButtonRightActionNumericalValue = new int[] {2, 5, 1};
    private char[] Action;
    public char ButtonLeftAction, ButtonRightAction;


    public int i,
        StonesInBasket,
        WinningNumberStones,
        ButtonLeftActionIndex,
        ButtonRightActionIndex,
        Difficulty = MainMenu.Difficulty;


    private void Start()
    {
        ButtonsValueGenerate();
        StonesInBasketUpdate();
    }

    public void OnClickLeft()
    {
        ButtonLeft.interactable = false;
        ButtonRight.interactable = false;
        StonesInBasket = GameButtonLeft.getResult(StonesInBasket);
        StonesInBasketUpdate();
        StonesInBasket =
            computer.AiStep(GameButtonLeft, GameButtonRight, StonesInBasket, WinningNumberStones, Difficulty);
        Invoke("StonesInBasketUpdate", 2);
        Invoke("ButtonActive", 2);
    }

    public void OnClickRight()
    {
        ButtonLeft.interactable = false;
        ButtonRight.interactable = false;
        StonesInBasket = GameButtonRight.getResult(StonesInBasket);
        StonesInBasketUpdate();
        StonesInBasket =
            computer.AiStep(GameButtonLeft, GameButtonRight, StonesInBasket, WinningNumberStones, Difficulty);
        Invoke("StonesInBasketUpdate", 2);
        Invoke("ButtonActive", 2);
        Debug.Log(ButtonLeft.interactable);
    }

    private void StonesInBasketUpdate()
    {
        ResultPanel.text = System.Convert.ToString(StonesInBasket);
    }

    private void ButtonActive()
    {
        ButtonRight.interactable = true;
        ButtonLeft.interactable = true;
    }


    private void ButtonsValueGenerate()
    {
        Action = new char[] {'*', '+'};
        GameButtonLeft = new GameButton();
        GameButtonRight = new GameButton();
        computer = new AI();
        i = Random.Range(0, ButtonLeftActionNumericalValue.Length);
        ButtonLeftActionIndex = Random.Range(0, Action.Length);
        ButtonRightActionIndex = Random.Range(0, Action.Length);
        ButtonRightAction = Action[ButtonRightActionIndex];
        ButtonLeftAction = Action[ButtonLeftActionIndex];
        ButtonLeft.GetComponentInChildren<Text>().text =
            ButtonLeftAction + System.Convert.ToString(ButtonLeftActionNumericalValue[i]);
        ButtonRight.GetComponentInChildren<Text>().text =
            ButtonRightAction + System.Convert.ToString(ButtonRightActionNumericalValue[i]);
        GameButtonLeft.SetGameButton(ButtonLeftAction, ButtonLeftActionNumericalValue[i]);
        GameButtonRight.SetGameButton(ButtonRightAction, ButtonRightActionNumericalValue[i]);
        StonesInBasket = Random.Range(2, 20);
        WinningNumberStones = Random.Range(20, 40);
    }
}