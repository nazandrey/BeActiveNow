using System;
using _Project.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PauseSetter : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseOverlay;

    public Sprite imagePaused;
    public Sprite imageUnpaused;
    
    private bool _paused = false;
    private Image _image;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
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
        _image.sprite = _paused ? imagePaused : imageUnpaused;
        Time.timeScale = paused ? 0 : 1;
        pauseOverlay.SetActive(paused);
    }
}
