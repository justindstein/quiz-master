using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerImageController : MonoBehaviour
{
    public FloatVariable Duration;

    public FloatVariable TimerMaxFill;

    public UnityEvent<Component, System.Object> OnTimerExpired;

    private QuestionEntity question;

    private Image image;

    private QuizTimer quizTimer;

    private void Awake()
    {
        this.image = this.GetComponent<Image>();
        this.quizTimer = new QuizTimer(this.TimerMaxFill.Value, this.Duration.Value);
    }

    public void SetQuestion(QuestionEntity question)
    {
        this.question = question;
    }

    private void FixedUpdate()
    {
        this.quizTimer.ApplyChange(Time.deltaTime);
        this.image.fillAmount = this.quizTimer.GetTimerFill();

        if (this.quizTimer.IsDone())
        {
            this.OnTimerExpired.Invoke(this, this.question);
            Destroy(this.gameObject);
        }
    }

    private class QuizTimer
    {
        private float timerMaxFill;

        private float duration;

        private float elapsedTime;

        public QuizTimer(float timerMaxFill, float duration)
        {
            this.timerMaxFill = timerMaxFill;
            this.duration = duration;
            this.elapsedTime = 0f;
        }

        public void ApplyChange(float value)
        {
            this.elapsedTime += value;
        }

        public bool IsDone()
        {
            return (this.elapsedTime >= this.duration);
        }

        public float GetTimerFill()
        {
            return Mathf.Max(this.timerMaxFill - (this.elapsedTime / this.duration), 0);
        }
    }
}
