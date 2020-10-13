using UnityEngine;

public class PauseSetter : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseOverlay;

    private bool _paused = false;

    public void PauseToggle()
    {
        ApplyPause(!_paused);
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
