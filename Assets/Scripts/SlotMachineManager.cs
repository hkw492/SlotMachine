using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineManager : MonoBehaviour
{
    public ReelController[] reels;       
    public RNGSystem rng;
    public WinChecker winChecker;
    public BalanceManager balanceManager;
    public UIManager uiManager;
    public SymbolDatabase database;

    public Image leverImage;
    public Sprite leverNormal;    
    public Sprite leverPulled;    

    private bool isPlaying; 

    public void OnSpinButtonPressed()
    {
        if (isPlaying) return;

        if (!balanceManager.CanBet())
        {
            uiManager.ShowMessage("Insufficient Balance");
            return;
        }
        StartCoroutine(PlayRound());
    }

    IEnumerator PlayRound()
    {
        isPlaying = true;
        uiManager.SetSpinButtonInteractable(false);

        
        if (leverImage != null && leverPulled != null)
            leverImage.sprite = leverPulled;

        balanceManager.PlaceBet();

        int[] results = rng.GenerateResults(reels.Length, database.symbols.Length);

        for (int i = 0; i < reels.Length; i++)
            reels[i].Spin(results[i]);

        for (int i = 0; i < reels.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => !reels[i].IsSpinning());
        }

        
        if (leverImage != null && leverNormal != null)
            leverImage.sprite = leverNormal;

        int payout = winChecker.CheckWin(results);
        if (payout > 0)
        {
            int totalWin = payout * balanceManager.GetBet();
            balanceManager.AddWinnings(totalWin);
            uiManager.ShowWin(totalWin);
        }
        else
        {
            uiManager.ShowLose();
        }

        isPlaying = false;
        uiManager.SetSpinButtonInteractable(true);
    }
}