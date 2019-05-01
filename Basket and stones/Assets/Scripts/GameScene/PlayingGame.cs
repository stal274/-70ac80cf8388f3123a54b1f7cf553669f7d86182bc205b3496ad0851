using System;
using System.Diagnostics;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayingGame : MonoBehaviour, IPhoneButtons
{
    public Button ButtonLeft, ButtonRight;
    public GameObject ButtonPanel, WinOrLosePanel;

    public Text ResultPanel, StonesToWinPanel, VictoryPanel;

    protected static GameButton GameButtonLeft, GameButtonRight;

    private Ai Computer;
    private readonly int[] ButtonLeftActionNumericalValue = {3, 2, 2, 3, 4, 6, 5, 3, 2, 6, 4, 2, 3, 5, 4};
    private readonly int[] ButtonRightActionNumericalValue = {2, 5, 7, 4, 3, 5, 4, 6, 4, 7, 3, 2, 7, 3, 6};
    private readonly char[] Action1 = {'+', '*', '+', '+', '-', '+', '-', '+', '*', '+', '-', '+', '-', '+', '-'};
    private readonly char[] Action2 = {'-', '-', '-', '-', '+', '-', '+', '-', '-', '-', '+', '-', '+', '-', '+'};
    private Animation Anim;
    private string WhoseTurn;
    private bool StopGame;
    private char ButtonLeftAction, ButtonRightAction;
    private Perk Perk0, Perk1, Perk2;

    public static int index = 1,
        StonesInBasket,
        WinningNumberStones,
        ActionIndex;

    private int Tick , STick;

    private static readonly byte Difficulty = MainMenu.Difficulty;

    /*private Stones stones;*/

    private void Start()
    {
        // ReSharper disable once Unity.IncorrectMonoBehaviourInstantiation
        Computer = new Ai();
        StonesInBasket = StonesInBasketGenerate();
        ButtonsValueGenerate();
        StonesInBasketUpdate();

        switch (Difficulty)
        {
            case 0:
                STick = 4;
                break;
            case 1:
                STick = 3;
                break;
            case 2:
                STick = 2;
                break;
        }

        /*stones.GetComponent<Stones>();*/
    }

    private int StonesInBasketGenerate()
    {
        var i = 0;
        if (Difficulty == 0)
            i = Random.Range(10, 26);
        else if (Difficulty == 1)
            i = Random.Range(15, 47);
        else if (Difficulty == 2) i = Random.Range(47, 81);

        WinningNumberStones = Random.Range(i + 15, i + 25);


        return i;
    }


    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Retry_Button":
                SceneManager.LoadScene("TestGameScene");
                GameObject.Find("SFX_Menu_button").GetComponent<AudioSource>().Play();
                break;
            case "MainMenu_Button":
                SceneManager.LoadScene("Main menu");
                GameObject.Find("SFX_Menu_button").GetComponent<AudioSource>().Play();
                break;
        }
    }

    private void ButtonActive()
    {
        if (StopGame) return;
        ButtonRight.interactable = true;
        ButtonLeft.interactable = true;
        var i = Random.Range(0, 2);
        switch (i)
        {
            case 0:
                GameObject.Find("SFX_Tern_button_3").GetComponent<AudioSource>().Play();
                break;
            case 1:
                GameObject.Find("SFX_Tern_button_4").GetComponent<AudioSource>().Play();
                break;
        }
    }

    private void ButtonPanelVision()
    {
        if (StopGame)

        {
            ButtonPanel.active = false;
        }
    }

    protected void StonesInBasketUpdate()
    {
        ResultPanel.text = Convert.ToString(StonesInBasket);
        IsVictory();
        ButtonPanelVision();
    }

    private void IsVictory()
    {
        if (StonesInBasket == WinningNumberStones)
        {
            if (StonesInBasket == WinningNumberStones && WhoseTurn == "Human")
            {
                WinOrLosePanel.SetActive(true);
                VictoryPanel.text = "Вы выиграли!";
                GameObject.Find("SFX_Win").GetComponent<AudioSource>().Play();
                StopGame = true;
            }
            else if (StonesInBasket == WinningNumberStones && WhoseTurn == "Computer")
            {
                WinOrLosePanel.SetActive(true);
                VictoryPanel.text = "Сожалею, но машина оказалась умней!";
                GameObject.Find("SFX_Lose").GetComponent<AudioSource>().Play();
                StopGame = true;
            }
        }
    }

    private void ButtonsValueGenerate()
    {
        GameButtonLeft = gameObject.AddComponent<GameButton>();
        GameButtonRight = gameObject.AddComponent<GameButton>();
        index = Random.Range(0, ButtonLeftActionNumericalValue.Length);
        ActionIndex = index;
        ButtonLeftAction = Action1[ActionIndex];
        ButtonRightAction = Action2[ActionIndex];
        /*CheckActions();*/
        ButtonLeft.GetComponentInChildren<Text>().text =
            ButtonLeftAction + Convert.ToString(ButtonLeftActionNumericalValue[index]);
        ButtonRight.GetComponentInChildren<Text>().text =
            ButtonRightAction + Convert.ToString(ButtonRightActionNumericalValue[index]);
        GameButtonLeft.SetGameButton(ButtonLeftAction, ButtonLeftActionNumericalValue[index]);
        GameButtonRight.SetGameButton(ButtonRightAction, ButtonRightActionNumericalValue[index]);
        StonesToWinPanel.text = WinningNumberStones.ToString();
    }

    public void OnMouseDown(GameObject gameObject)
    {
        WhoseTurn = "Human";
        ButtonLeft.interactable = false;
        ButtonRight.interactable = false;
        var i = Random.Range(0, 2);
        switch (i)
        {
            case 0:
                GameObject.Find("SFX_Tern_button_1").GetComponent<AudioSource>().Play();
                break;
            case 1:
                GameObject.Find("SFX_Tern_button_2").GetComponent<AudioSource>().Play();
                break;
        }

        if (gameObject.name == "LeftChoise_Button")
            StonesInBasket = GameButtonLeft.getResult(StonesInBasket);
        else if (gameObject.name == "RightChoise_Button") StonesInBasket = GameButtonRight.getResult(StonesInBasket);

        StonesInBasketUpdate();
        while (!StopGame)
        {
            WhoseTurn = "Computer";
            StonesInBasket =
                Computer.AiStep();
            Invoke("StonesInBasketUpdate", 2);
            break;
        }

        Invoke("ButtonActive", 2);
        Tick += 1;

        if (Tick == STick)
        {
            ButtonsValueGenerate();
            Tick = 0;
        }
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    /*private void CheckActions()
    {
        while (true)
        {
            if (ButtonLeftAction == ButtonRightAction)
            {
                ActionIndex = Random.Range(0, Action1.Length);
                ButtonLeftAction = Action1[ActionIndex];
                continue;
            }

            break;
        }
    }*/

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            HardwareButtons(KeyCode.Escape);
        }
    }

    public void HardwareButtons(KeyCode EscapeButton)
    {
        if (Input.GetKey(EscapeButton))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}