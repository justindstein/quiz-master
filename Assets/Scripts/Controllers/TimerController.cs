using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Image ParentImage;

    public Sprite DefaultSprite;

    public Sprite PausedSprite;

    public FloatVariable TimerMaxFill;

    public FloatVariable QuestionDuration;

    public UnityEvent TimerExpired;

    private float elapsedTime;

    private bool timerActive;

    private void FixedUpdate()
    {
        if (this.timerActive)
        {
            this.elapsedTime += Time.deltaTime;
            this.UpdateTimerImage(this.ParentImage, this.TimerMaxFill.Value, this.elapsedTime, this.QuestionDuration.Value);

            if(this.elapsedTime > this.QuestionDuration.Value)
            {
                this.TimerExpired.Invoke();
            }
        }
    }

    // OnLoadQuestion
    public void StartTimer()
    {
        this.elapsedTime = 0;
        this.ParentImage.sprite = this.DefaultSprite;
        this.timerActive = true;
    }

    // OnCorrectAnswer
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
