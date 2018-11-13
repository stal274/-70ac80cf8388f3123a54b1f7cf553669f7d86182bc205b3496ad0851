using UnityEngine;
using UnityEngine.UI;

public class PlayingGame : MonoBehaviour
{
    public Button ButtonLeft,ButtonRight;
    public Text ResultPanel;
    public GameButton GameButtonLeft, GameButtonRight;
    private AI computer;
    private int[] ButtonLeftActionNumericalValue = new int[] { 3, 2, 2 };
    private int[] ButtonRightActionNumericalValue = new int[] {2,5,1};
    private char[] Action;
    public char ButtonLeftAction, ButtonRightAction;
    public int i, StonesInBasket, WinningNumberStones, ButtonLeftActionIndex, ButtonRightActionIndex;
    
    
    private void Start()
    {
        ButtonsValueGenerate();
        StonesInBasketUpdate();
    }
    public void OnClickLeft()
    {
        StonesInBasket =  GameButtonLeft.getResult(StonesInBasket);
        StonesInBasketUpdate();
        StonesInBasket = computer.AiStep(GameButtonLeft, GameButtonRight, StonesInBasket, WinningNumberStones);
        Invoke("StonesInBasketUpdate", 2);
    }
    public void OnClickRight()
    {
        StonesInBasket = GameButtonRight.getResult(StonesInBasket);
        StonesInBasketUpdate();
        StonesInBasket = computer.AiStep(GameButtonLeft, GameButtonRight, StonesInBasket, WinningNumberStones);
        Invoke("StonesInBasketUpdate", 2);

    }
   private void StonesInBasketUpdate()
    {
        ResultPanel.GetComponent<Text>().text = System.Convert.ToString(StonesInBasket);
    }
    
  private void ButtonsValueGenerate()
    {
        Action = new char[] { '*', '+' };
        GameButtonLeft = new GameButton();
        GameButtonRight = new GameButton();
        computer = new AI();
        i = Random.Range(0, ButtonLeftActionNumericalValue.Length);
        ButtonLeftActionIndex = Random.Range(0, Action.Length);
        ButtonRightActionIndex = Random.Range(0, Action.Length);
        ButtonRightAction = Action[ButtonRightActionIndex];
        ButtonLeftAction = Action[ButtonLeftActionIndex];
        ButtonLeft.GetComponentInChildren<Text>().text = ButtonLeftAction + System.Convert.ToString(ButtonLeftActionNumericalValue[i]);
        ButtonRight.GetComponentInChildren<Text>().text = ButtonRightAction + System.Convert.ToString(ButtonRightActionNumericalValue[i]);
        GameButtonLeft.SetGameButton(ButtonLeftAction, ButtonLeftActionNumericalValue[i]);
        GameButtonRight.SetGameButton(ButtonRightAction, ButtonRightActionNumericalValue[i]);
        StonesInBasket = Random.Range(2, 20);
        WinningNumberStones = Random.Range(20, 40);
    }

}
