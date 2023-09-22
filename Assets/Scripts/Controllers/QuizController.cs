using UnityEngine;

public class QuizController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    public QuestionSet[] QuestionSets;

    public void StartQuiz(int index)
    {
        this.QuizStateManager.StartQuiz(this.QuestionSets[index]);
    }
}
