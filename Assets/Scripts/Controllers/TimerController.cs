using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public QuizState QuizState;

    public QuizStateManager QuizStateManager;

    public Image ParentImage;

    public Sprite DefaultSprite;

    public Sprite PausedSprite;

    public FloatVariable TimerMaxFill;

    public FloatVariable QuestionDuration;

    public FloatVariable AnswerDuration;

    public UnityEvent TimerExpired;

    public UnityEvent LoadQuestion;

    public UnityEvent QuizFinished;

    private float elapsedTime;

    // TODO: delete the disabled event listener for OnLoadQuestion

    private void FixedUpdate()
    {
        // TODO: Cleanup redundancies in this
        if (this.QuizState.IsQuestionState())
        {
            this.elapsedTime += Time.deltaTime;
            this.updateTimer(this.ParentImage, this.elapsedTime, this.QuestionDuration.Value);

            if (this.elapsedTime > this.QuestionDuration.Value)
            {
                //Debug.Log(string.Format("TimerController.FixedUpdate TimerExpired"));
                this.TimerExpired.Invoke();
            }
        }
        else if (this.QuizState.IsAnswerState())
        {
            this.elapsedTime += Time.deltaTime;
            this.updateTimer(this.ParentImage, this.elapsedTime, this.AnswerDuration.Value);

            if (this.elapsedTime > this.AnswerDuration.Value)
            {
                //Debug.Log(string.Format("TimerController.FixedUpdate LoadQuestion"));
                this.LoadQuestion.Invoke();
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

    // OnLoadQuestion
    public void ResetTimer()
    {
        //Debug.Log("TimerController.ResetTimer");
        if (this.QuizState.IsQuestionState())
        {
            this.ParentImage.sprite = this.DefaultSprite;
            this.ParentImage.fillClockwise = false;
        }

        else if (this.QuizState.IsAnswerState())
        {
            this.ParentImage.sprite = this.PausedSprite;
            this.ParentImage.fillClockwise = true;
        }

        this.elapsedTime = 0;
    }

    public void SetQuizState(string quizStateType)
    {
        this.QuizState.SetValue(quizStateType);
    }

    public void GetNextQuestion()
    {
        if (QuizStateManager.IsQuestionRemaining())
        {
            this.QuizStateManager.LoadQuestion(this.QuizStateManager.GetNextQuestion());
        }

        // TODO: TimerController shouldnt be in charge of finishing a quiz
        else
        {
            Debug.Log("GetNextQuestion: QuizFinished.Invoke()");
            this.QuizFinished.Invoke();
        }
    }
}
