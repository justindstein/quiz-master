using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    public Sprite DefaultSprite;

    public Sprite PausedSprite;

    public FloatVariable TimerMaxFill;

    public FloatVariable QuestionDuration;

    public FloatVariable AnswerDuration;

    public UnityEvent OnQuestionTimerExpired;

    public UnityEvent OnAnswerTimerExpired;

    private Image parentImage;

    private QuizTimer quizTimer;

    private void Awake()
    {
        this.parentImage = this.GetComponent<Image>();
        this.quizTimer = new QuizTimer(this.TimerMaxFill.Value, QuizStateType.QUESTION, this.QuestionDuration.Value);
    }

    private void FixedUpdate()
    {
        //this.quizState.IsAnswerState()

        // Question timer
        if (this.quizTimer.GetTimerType() == QuizStateType.QUESTION)
        {
            updateTimer(this.PausedSprite, true, QuizStateType.ANSWER, this.QuestionDuration.Value, this.OnQuestionTimerExpired);

            //this.quizTimer.ApplyChange(Time.deltaTime);
            //this.parentImage.fillAmount = this.quizTimer.GetTimerFill();

            //if (this.quizTimer.IsDone())
            //{
            //    this.parentImage.sprite = this.PausedSprite;
            //    this.parentImage.fillClockwise = true;
            //    this.quizTimer.Reset(QuizStateType.ANSWER, this.AnswerDuration.Value);
            //    this.OnQuestionTimerExpired.Invoke();
            //}
        }

        // Answer timer
        else if (this.quizTimer.GetTimerType() == QuizStateType.ANSWER)
        {
            updateTimer(this.DefaultSprite, false, QuizStateType.QUESTION, this.AnswerDuration.Value, this.OnAnswerTimerExpired);

            //this.quizTimer.ApplyChange(Time.deltaTime);
            //this.parentImage.fillAmount = this.quizTimer.GetTimerFill();

            //if (this.quizTimer.IsDone())
            //{
            //    this.parentImage.sprite = this.DefaultSprite;
            //    this.parentImage.fillClockwise = false;
            //    this.quizTimer.Reset(QuizStateType.QUESTION, this.AnswerDuration.Value);
            //    this.OnAnswerTimerExpired.Invoke();
            //}
        }
    }

    private void updateTimer(Sprite sprite, bool fillClockwise, QuizStateType quizStateType, float duration, UnityEvent unityEvent)
    {
        this.quizTimer.ApplyChange(Time.deltaTime);
        this.parentImage.fillAmount = this.quizTimer.GetTimerFill();

        if (this.quizTimer.IsDone())
        {
            this.parentImage.sprite = sprite;
            this.parentImage.fillClockwise = fillClockwise;
            this.quizTimer.Reset(quizStateType, this.AnswerDuration.Value);
            unityEvent.Invoke();
        }
    }

    private class QuizTimer
    {
        private float timerMaxFill;

        private QuizStateType timerType;

        private float duration;

        private float elapsedTime;

        public QuizTimer(float timerMaxFill, QuizStateType timerType, float duration)
        {
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

        public void Reset(QuizStateType timerType, float duration)
        {
            this.elapsedTime = 0f;
        }

        public QuizStateType GetTimerType()
        {
            return this.timerType;
        }

        public float GetTimerFill()
        {
            return Mathf.Max(this.timerMaxFill - (this.elapsedTime / this.duration), 0);
        }
    }
}
