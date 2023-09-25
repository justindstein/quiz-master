using TMPro;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    public GameObject QuizButtonPrefab;

    public QuizStateManager QuizStateManager;

    public QuestionSet[] Quizzes;

    public GameEvent OnLoadMenu;

    private void Start()
    {
        this.OnLoadMenu.Raise();
    }

    /// <summary>
    /// Load a collection of quizzes into 'Quizzes' layout group.
    /// </summary>
    public void LoadQuizzes()
    {
        foreach (QuestionSet quiz in this.Quizzes)
        {
            // Instantiate a button
            GameObject quizButton = instantiateAnswerButton(this.QuizButtonPrefab, quiz);

            // Set its parent to 'Answers' GameObject
            quizButton.transform.SetParent(this.transform);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prefab">The prefab to instantiate</param>
    /// <param name="quiz">The associated quiz</param>
    /// <returns>Instantiated button gameobject</returns>
    private GameObject instantiateAnswerButton(GameObject prefab, QuestionSet quiz)
    {
        GameObject quizButton = Instantiate(prefab);

        quizButton.GetComponent<QuizButtonController>().SetQuizStateManager(this.QuizStateManager);
        quizButton.GetComponent<QuizButtonController>().SetQuiz(quiz);

        quizButton.GetComponentInChildren<TextMeshProUGUI>().SetText(quiz.Name);

        return quizButton;
    }
}
