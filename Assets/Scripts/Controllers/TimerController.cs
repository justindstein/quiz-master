using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Image ParentImage;

    public Sprite DefaultSprite;

    public Sprite PausedSprite;

    public float TimeToAnswer;

    private float maxFillAmount = 1;

    private float elapsedTime;

    private bool isTimerActive;

    void FixedUpdate()
    {
        if (isTimerActive)
        {
            this.elapsedTime += Time.deltaTime;
            this.UpdateTimerImage(this.ParentImage, this.maxFillAmount, this.elapsedTime, this.TimeToAnswer);
        }
    }

    public void StartTimer()
    {
        this.elapsedTime = 0;
        this.isTimerActive = true;
        this.UpdateTimerImage(this.ParentImage, this.maxFillAmount, this.elapsedTime, this.TimeToAnswer);
        this.ParentImage.sprite = this.DefaultSprite;
    }

    public void StopTimer()
    {
        this.isTimerActive = false;
        this.ParentImage.sprite = this.PausedSprite;
    }

    private void UpdateTimerImage(Image image, float maxFillAmount, float elapsedTime, float timeToAnswer)
    {
        float total = Mathf.Max(maxFillAmount - (elapsedTime / TimeToAnswer), 0);
        this.ParentImage.fillAmount = total;

    #if UNITY_EDITOR
        //Debug.Log(string.Format("{0}: Mathf.Max({1} - ({2} / {3}), 0)", total, maxFillAmount, elapsedTime, timeToAnswer));
    #endif
    }
}

