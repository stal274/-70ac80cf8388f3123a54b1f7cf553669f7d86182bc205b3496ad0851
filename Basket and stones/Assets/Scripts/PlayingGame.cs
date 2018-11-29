﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayingGame : MonoBehaviour
{
    public Button ButtonLeft, ButtonRight;


    public Text ResultPanel, Victory;

    private GameButton GameButtonLeft, GameButtonRight;
    private AI computer;
    private int[] ButtonLeftActionNumericalValue = {3, 2, 2};
    private int[] ButtonRightActionNumericalValue =  {2, 5, 7};
    private char[] Action;
    private string WhoseTurn;
    public char ButtonLeftAction, ButtonRightAction;


    public int i,
        StonesInBasket,
        WinningNumberStones,
        ButtonLeftActionIndex,
        ButtonRightActionIndex,
        Difficulty = MainMenu.Difficulty;

    /*private Stones stones;*/

    private void Start()
    {
        ButtonsValueGenerate();
        StonesInBasketUpdate();
        /*stones.GetComponent<Stones>();*/ 
    }

    public void OnClickLeft()
    {
        WhoseTurn = "Human";
        ButtonLeft.interactable = false;
        ButtonRight.interactable = false;
        StonesInBasket = GameButtonLeft.getResult(StonesInBasket);
        StonesInBasketUpdate();
        WhoseTurn = "Computer";
        StonesInBasket =
            computer.AiStep(GameButtonLeft, GameButtonRight, StonesInBasket, WinningNumberStones, Difficulty);
        Invoke("StonesInBasketUpdate", 2);
        Invoke("ButtonActive", 2);
    }

    public void OnClickRight()
    {
        WhoseTurn = "Human";
        ButtonLeft.interactable = false;
        ButtonRight.interactable = false;
        StonesInBasket = GameButtonRight.getResult(StonesInBasket);
        StonesInBasketUpdate();
        WhoseTurn = "Computer";
        StonesInBasket =
            computer.AiStep(GameButtonLeft, GameButtonRight, StonesInBasket, WinningNumberStones, Difficulty);
        Invoke("StonesInBasketUpdate", 2);
        Invoke("ButtonActive", 2);
    }

    private void StonesInBasketUpdate()
    {
        ResultPanel.text = Convert.ToString(StonesInBasket);
        IsVictory();
    }

    private void ButtonActive()
    {
        ButtonRight.interactable = true;
        ButtonLeft.interactable = true;
    }

    private void IsVictory()
    {
        
    }

    private void CheckActions()
    {
        if (ButtonLeftAction==ButtonRightAction)
        {
            ButtonLeftActionIndex = Random.Range(0, Action.Length);
            ButtonLeftAction = Action[ButtonLeftActionIndex];
            CheckActions();
        } 
    }

    private void ButtonsValueGenerate()
    {
        Action =new []{'*', '+', '-', '/'};
        GameButtonLeft = new GameButton();
        GameButtonRight = new GameButton();
        computer = new AI();
        i = Random.Range(0, ButtonLeftActionNumericalValue.Length);
        ButtonLeftActionIndex = Random.Range(0, Action.Length);
        ButtonRightActionIndex = Random.Range(0, Action.Length);
        ButtonLeftAction = Action[ButtonLeftActionIndex];
        ButtonRightAction = Action[ButtonRightActionIndex];
        CheckActions();
        ButtonLeft.GetComponentInChildren<Text>().text =
            ButtonLeftAction + Convert.ToString(ButtonLeftActionNumericalValue[i]);
        ButtonRight.GetComponentInChildren<Text>().text =
            ButtonRightAction + Convert.ToString(ButtonRightActionNumericalValue[i]);
        GameButtonLeft.SetGameButton(ButtonLeftAction, ButtonLeftActionNumericalValue[i]);
        GameButtonRight.SetGameButton(ButtonRightAction, ButtonRightActionNumericalValue[i]);
        StonesInBasket = Random.Range(2, 20);
        WinningNumberStones = Random.Range(20, 40);
        Victory.text = "Победное число камней: " + WinningNumberStones;
    }
}