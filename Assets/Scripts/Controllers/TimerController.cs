using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Image ParentImage;

    public Sprite DefaultSprite;

    public Sprite PausedSprite;

    private float maxFillAmount = 1;

    private float elapsedTime;

    public GameEvent OnTimerExpired;

    private bool timerActive;

    public UnityEvent TimerExpired;

    public FloatVariable QuestionDuration;

    void FixedUpdate()
    {
        if (this.timerActive)
        {
            this.elapsedTime += Time.deltaTime;
            this.UpdateTimerImage(this.ParentImage, this.maxFillAmount, this.elapsedTime, this.QuestionDuration.Value);

            if(this.elapsedTime > this.QuestionDuration.Value)
            {
                this.TimerExpired.Invoke();
                this.timerActive = false;
            }
        }
    }

    public void StartTimer()
    {
        this.elapsedTime = 0;
        this.timerActive = true;
        this.UpdateTimerImage(this.ParentImage, this.maxFillAmount, this.elapsedTime, this.QuestionDuration.Value);
        this.ParentImage.sprite = this.DefaultSprite;
    }

    public void StopTimer()
    {
        this.timerActive = false;
        this.ParentImage.sprite = this.PausedSprite;
    }

    private void UpdateTimerImage(Image image, float maxFillAmount, float elapsedTime, float timeToAnswer)
    {
        float total = Mathf.Max(maxFillAmount - (elapsedTime / this.QuestionDuration.Value), 0);
        this.ParentImage.fillAmount = total;

    #if UNITY_EDITOR
        Debug.Log(string.Format("{0}: Mathf.Max({1} - ({2} / {3}), 0)", total, maxFillAmount, elapsedTime, timeToAnswer));
    #endif
    }
}
