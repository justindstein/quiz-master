using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    public Image ParentImage;

    public Sprite DefaultSprite;

    public Sprite PausedSprite;

    public FloatVariable TimerMaxFill;

    public FloatVariable QuestionDuration;

    public FloatVariable AnswerDuration;

    public UnityEvent TimerExpired;

    private QuizState quizState = new QuizState();

    private float elapsedTime;

    private void FixedUpdate()
    {
        // TODO: Cleanup redundancies in this
        if (this.quizState.IsQuestionState())
        {
            this.elapsedTime += Time.deltaTime;
            this.updateTimer(this.ParentImage, this.elapsedTime, this.QuestionDuration.Value);

            if (this.elapsedTime > this.QuestionDuration.Value)
            {
                this.TimerExpired.Invoke();
            }
        }

        else if (this.quizState.IsAnswerState())
        {
            this.elapsedTime += Time.deltaTime;
            this.updateTimer(this.ParentImage, this.elapsedTime, this.AnswerDuration.Value);

            if (this.elapsedTime > this.AnswerDuration.Value)
            {
                this.QuizStateManager.LoadNextQuestion();
            }
        }
    }

    private void updateTimer(Image image, float elapsedTime, float timeToAnswer)
    {
        float fillFraction = Mathf.Max(TimerMaxFill.Value - (elapsedTime / timeToAnswer), 0);
        this.ParentImage.fillAmount = fillFraction;

#if UNITY_EDITOR
        //Debug.Log(string.Format("{0}: Mathf.Max({1} - ({2} / {3}), 0)", fillFraction, TimerMaxFill.Value, elapsedTime, timeToAnswer));
#endif
    }

    public void ResetTimer()
    {
        if (this.quizState.IsQuestionState())
        {
            this.ParentImage.sprite = this.DefaultSprite;
            this.ParentImage.fillClockwise = false;
        }

        else if (this.quizState.IsAnswerState())
        {
            this.ParentImage.sprite = this.PausedSprite;
            this.ParentImage.fillClockwise = true;
        }

        this.elapsedTime = 0;
    }

    public void QuestionState()
    {
        this.quizState.SetValue(QuizStateType.QUESTION);
    }

    public void AnswerState()
    {
        this.quizState.SetValue(QuizStateType.ANSWER);
    }
}
