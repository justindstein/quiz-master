using UnityEngine;
using static QuizStateManager;

public class TimerController : MonoBehaviour
{
    public GameObject QuestionTimerPrefab;

    public GameObject AnswerTimerPrefab;

    public void CreateQuestionTimer(Component component, System.Object obj)
    {
        if (obj is QuestionPresentation question)
        {
            // Clear out previous answers
            this.DeleteTimers();

            // Instantiate a button
            GameObject questionTimer = Instantiate(this.QuestionTimerPrefab);
            questionTimer.GetComponent<TimerImageController>().SetQuestion(question);

            // Set its parent to 'Answers' GameObject
            questionTimer.transform.SetParent(this.transform);
        }

    }

    public void CreateAnswerTimer(Component component, System.Object obj)
    {
        if (obj is QuestionPresentation question)
        {
            // Clear out previous answers
            this.DeleteTimers();

            // Instantiate a button
            GameObject answerTimer = Instantiate(this.AnswerTimerPrefab);
            answerTimer.GetComponent<TimerImageController>().SetQuestion(question);

            // Set its parent to 'Answers' GameObject
            answerTimer.transform.SetParent(this.transform);
        }
    }

    private void DeleteTimers()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}
