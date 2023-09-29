using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public GameObject TimerImagePrefab;

    public Sprite DefaultSprite;

    public Sprite PausedSprite;

    public FloatVariable TimerMaxFill;

    public FloatVariable QuestionDuration;

    public FloatVariable AnswerDuration;

    public UnityEvent<Component, System.Object> OnQuestionTimerExpired;

    public UnityEvent<Component, System.Object> OnAnswerTimerExpired;

    private Image image;

    //private QuizTimer quizTimer;

    private void Awake()
    {
        //this.image = this.GetComponent<Image>();
        //this.quizTimer = new QuizTimer(this.TimerMaxFill.Value, QuizStateType.QUESTION, this.QuestionDuration.Value);
    }

    public void CreateQuestionTimer(Component component, System.Object obj)
    {
        // Clear out previous answers
        this.DeleteTimers();

        // Instantiate a button
        GameObject answerButton = instantiateAnswerButton(this.TimerImagePrefab);

        // Set its parent to 'Answers' GameObject
        answerButton.transform.SetParent(this.transform);
    }

    public void CreateAnswerTimer(Component component, System.Object obj)
    {
        // Clear out previous answers
        this.DeleteTimers();

        // Instantiate a button
        GameObject answerButton = instantiateAnswerButton(this.TimerImagePrefab);

        // Set its parent to 'Answers' GameObject
        answerButton.transform.SetParent(this.transform);
    }

    private GameObject instantiateAnswerButton(GameObject prefab)
    {
        GameObject answerButton = Instantiate(prefab);

        return answerButton;
    }

    public void DeleteTimers()
    {
        for (int i = this.transform.childCount; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    // TODO: TimerTypeVariable and floatVariable
    //public void ResetTimer(string quizStateType)
    //{
    //    if (quizStateType.Equals("ANSWER"))
    //    {
    //        this.quizTimer.Reset(QuizStateType.ANSWER, this.AnswerDuration.Value);
    //    }
    //    else if (quizStateType.Equals("QUESTION"))
    //    {
    //        this.quizTimer.Reset(QuizStateType.QUESTION, this.QuestionDuration.Value);
    //    }
    //}
}
