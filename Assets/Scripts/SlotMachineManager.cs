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

    public AudioManager audioManager;

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
        uiManager.SetBetButtonsInteractable(false);

        if (audioManager != null)
            audioManager.PlayClick();

        if (leverImage != null && leverPulled != null && leverNormal != null)
        {
            leverImage.sprite = leverPulled;
            yield return new WaitForSeconds(0.3f);
            leverImage.sprite = leverNormal;
        }

        balanceManager.PlaceBet();

        int[] results = rng.GenerateResults(reels.Length, database.symbols.Length);

        if (audioManager != null)
            audioManager.PlaySpin();

        for (int i = 0; i < reels.Length; i++)
            reels[i].Spin(results[i]);

        for (int i = 0; i < reels.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => !reels[i].IsSpinning());
        }

        if (audioManager != null)
            audioManager.StopSpin();

        if (leverImage != null && leverNormal != null)
            leverImage.sprite = leverNormal;

        int payout = winChecker.CheckWin(results);
        if (payout > 0)
        {
            int totalWin = payout * balanceManager.GetBet();
            balanceManager.AddWinnings(totalWin);
            uiManager.ShowWin(totalWin);

            if (audioManager != null)
                audioManager.PlayWin();
        }
        else
        {
            uiManager.ShowLose();

            if (audioManager != null)
                audioManager.PlayLose();
        }

        isPlaying = false;
        uiManager.SetSpinButtonInteractable(true);
        uiManager.SetBetButtonsInteractable(true);
    }
}