using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Text balanceText;
    public Text messageText;
    public Text payoutTableText;
    public Button spinButton;
    public Text winText;
    public GameObject winPopup;

    public Text betText;
    public BalanceManager balanceManager;

    public Button increaseBetButton;
    public Button decreaseBetButton;

    void OnEnable()
    {
        BalanceManager.OnBalanceChanged += UpdateBalanceDisplay;
    }

    void OnDisable()
    {
        BalanceManager.OnBalanceChanged -= UpdateBalanceDisplay;
    }

    void UpdateBalanceDisplay(int balance)
    {
        Debug.Log("UpdateBalanceDisplay called: " + balance);
        balanceText.text = "Balance: Rs " + balance;
        if (betText != null && balanceManager != null)
            betText.text = "Bet: " + balanceManager.GetBet();
    }

    public void ShowWin(int amount)
    {
        messageText.text = "WIN!  +" + amount;
        messageText.color = Color.yellow;

        winPopup.SetActive(true);
        winText.text = "YOU WIN!  +" + amount;
    }

    public void ShowLose()
    {
        messageText.text = "Try Again";
        messageText.color = Color.white;

        winPopup.SetActive(false);
    }

    public void ShowMessage(string msg)
    {
        messageText.text = msg;
        messageText.color = Color.red;
    }

    public void SetSpinButtonInteractable(bool state)
    {
        spinButton.interactable = state;
    }

    public void SetBetButtonsInteractable(bool state)
    {
        if (increaseBetButton != null) increaseBetButton.interactable = state;
        if (decreaseBetButton != null) decreaseBetButton.interactable = state;
    }
}