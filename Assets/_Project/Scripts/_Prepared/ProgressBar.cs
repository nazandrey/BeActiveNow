using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image successBar;

    [SerializeField]
    private Image failBar;

    private int doorsAmount;

    private void Awake()
    {
        doorsAmount = 0;
        successBar.fillAmount = 0;
        failBar.fillAmount = 0;
    }

    public void UpdateStatus(bool isSuccessDoor)
    {
        if (isSuccessDoor && successBar != null)
            successBar.fillAmount += (float) 1/doorsAmount;
        else if (failBar != null)
            failBar.fillAmount += (float) 1/doorsAmount;
    }

    public void AddDoorsAmount(int doorsAmount)
    {
        this.doorsAmount += doorsAmount;
    }
}
