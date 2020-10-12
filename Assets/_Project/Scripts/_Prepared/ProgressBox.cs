using _Project.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBox : MonoBehaviour
{
    [SerializeField]
    private Image progressView;
    
    [SerializeField]
    private Sprite successView;

    [SerializeField]
    private Sprite nonSuccessView;

    private int progressAmount;
    private int currProgress;

    private void Awake()
    {
        progressAmount = 0;
        currProgress = 0;
    }

    public void UpdateProgress(bool isSuccess)
    {
        if (isSuccess)
            currProgress++;
        if (progressAmount == currProgress)
            progressView.sprite = successView;
    }

    public void InitProgressAmount(int progressAmount)
    {
        this.progressAmount += progressAmount;
        
        progressView.gameObject.SetActive(this.progressAmount > 0);
        progressView.sprite = nonSuccessView;
    }
}
