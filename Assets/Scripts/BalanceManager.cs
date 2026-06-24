using System;
using UnityEngine;

public class BalanceManager : MonoBehaviour
{
    public static event Action<int> OnBalanceChanged;
    private int balance = 1000;
    private int betAmount = 10;
    public bool CanBet() => balance >= betAmount;

    public void PlaceBet()
    {
        balance -= betAmount;
        OnBalanceChanged?.Invoke(balance); 
    }
    public void AddWinnings(int amount)
    {
        balance += amount;
        OnBalanceChanged?.Invoke(balance);
    }
    public int GetBalance() => balance;
    public int GetBet() => betAmount;
}