using UnityEngine;
using UnityEngine.Events;

public class QuizController : MonoBehaviour
{
    public QuestionSetManager QuestionSetManager;

    public CanvasState CanvasState;

    public QuestionSet[] QuestionSets;

    public UnityEvent LoadQuiz; // TODO: rename to QuizStarted 

    public void StartQuiz(int index)
    {
        Debug.Log("QuizController.StartQuiz:" + this.QuestionSets[index].name);
        this.QuestionSetManager.LoadQuestionSet(this.QuestionSets[index]);
        this.CanvasState.LoadQuestion(this.QuestionSetManager.GetNextQuestion());
        LoadQuiz.Invoke();
    }
}
