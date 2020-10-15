using System;
using _Project.Scripts;
using UnityEngine;

public class PauseSetter : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseOverlay;
    
    private bool _paused = false;
    
    private void Awake()
    {
        GameOverEventRaiser.GameOver += OnGameOver;
    }

    private void OnDestroy()
    {
        GameOverEventRaiser.GameOver -= OnGameOver;
    }

    private void OnGameOver(bool isWin)
    {
        Pause();
        gameObject.SetActive(false);
    }

    public void PauseToggle()
    {
        ApplyPause(!_paused);
        AudioManager.Instance.Play(_paused ? "Pause" : "Unpause");
    }

    public void Pause()
    {       
        ApplyPause(true);
    }
    
    public void Unpause()
    {       
        ApplyPause(false);
    }

    private void ApplyPause(bool paused)
    {
        _paused = paused;
        Time.timeScale = paused ? 0 : 1;
        pauseOverlay.SetActive(paused);
    }
}
