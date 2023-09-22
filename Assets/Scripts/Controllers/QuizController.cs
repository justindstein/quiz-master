using UnityEngine;
using UnityEngine.Events;

public class QuizController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    public QuestionSet[] QuestionSets;

    public UnityEvent LoadQuiz; // TODO: rename to QuizStarted 

    public void StartQuiz(int index)
    {
        Debug.Log("QuizController.StartQuiz:" + this.QuestionSets[index].name);
        this.QuizStateManager.LoadQuestionSet(this.QuestionSets[index]);
        LoadQuiz.Invoke(); // TODO: This should be invoked by QuizStateManager
    }
}
