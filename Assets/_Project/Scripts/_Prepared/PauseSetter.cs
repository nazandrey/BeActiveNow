using UnityEngine;

public class PauseSetter : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseOverlay;

    private bool paused = false;

    public void PauseToggle()
    {
        Time.timeScale = paused ? 1 : 0;        
        paused = !paused;
        pauseOverlay.SetActive(paused);
    }
}
