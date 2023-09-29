using System;
using UnityEngine;
using UnityEngine.Events;

public class TimerImageController : MonoBehaviour
{
    public FloatVariable QuestionDuration;

    public FloatVariable AnswerDuration;

    public UnityEvent<Component, System.Object> OnQuestionTimerExpired;

    public UnityEvent<Component, System.Object> OnAnswerTimerExpired;

    private Sprite sprite;

    private bool fillClockwise;

    private QuizStateType quizStateType;

    public void SetSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public void setFillClockwise(bool fillClockwise)
    {
        this.fillClockwise = fillClockwise;
    }

    private void setQuizStateType(QuizStateType quizStateType)
    {
        this.quizStateType = quizStateType;
    }

    private void FixedUpdate()
    {
        //this.quizState.IsAnswerState()

        // Question timer
        //if (this.quizTimer.GetTimerType() == QuizStateType.QUESTION)
        //{
        //    updateTimer(this.PausedSprite, true, QuizStateType.ANSWER, this.QuestionDuration.Value, this.OnQuestionTimerExpired);
        //}

        //// Answer timer
        //else if (this.quizTimer.GetTimerType() == QuizStateType.ANSWER)
        //{
        //    updateTimer(this.DefaultSprite, false, QuizStateType.QUESTION, this.AnswerDuration.Value, this.OnAnswerTimerExpired);
        //}
    }

    private void updateTimer(Sprite sprite, bool fillClockwise, QuizStateType quizStateType, float duration, UnityEvent<Component, System.Object> unityEvent)
    {
        //this.quizTimer.ApplyChange(Time.deltaTime);
        //this.image.fillAmount = this.quizTimer.GetTimerFill();

        //if (this.quizTimer.IsDone())
        //{
        //    this.image.sprite = sprite;
        //    this.image.fillClockwise = fillClockwise;
        //    this.quizTimer.Reset(quizStateType, this.AnswerDuration.Value);
        //    unityEvent.Invoke(this, null);
        //}
    }

    private class QuizTimer
    {
        private float timerMaxFill;

        private QuizStateType timerType;

        private float duration;

        private float elapsedTime;

        public QuizTimer(float timerMaxFill, QuizStateType timerType, float duration)
        {
            this.timerMaxFill = timerMaxFill;
            this.timerType = timerType;
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
            this.timerType = timerType;
            this.elapsedTime = duration;
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