using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public AudioSource spinSound;
    public AudioSource winSound;
    public AudioSource loseSound;
    public AudioSource clickSound;

    public void PlaySpin()
    {
        spinSound.Play();
    }

    public void PlayWin()
    {
        winSound.Play();
    }

    public void PlayLose()
    {
        loseSound.Play();
    }

    public void PlayClick()
    {
        clickSound.Play();
    }

    public void StopSpin()
    {
        spinSound.Stop();
    }
}