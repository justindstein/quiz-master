using TMPro;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    public GameObject QuizButtonPrefab;

    public QuestionSet[] Quizzes;

    private void OnEnable()
    {
        this.LoadQuizzes();
    }

    /// <summary>
    /// Load a collection of quizzes into 'Quizzes' layout group
    /// </summary>
    public void LoadQuizzes()
    {
        foreach (QuestionSet quiz in this.Quizzes)
        {
            // Instantiate a button
            GameObject quizButton = instantiateQuizButton(this.QuizButtonPrefab, quiz);

            // Set its parent to 'Answers' GameObject
            quizButton.transform.SetParent(this.transform);
        }
    }

    /// <summary>
    /// Instantiates a new quiz button
    /// </summary>
    /// <param name="prefab">The prefab to instantiate</param>
    /// <param name="quiz">The associated quiz</param>
    /// <returns>Instantiated button gameobject</returns>
    private GameObject instantiateQuizButton(GameObject prefab, QuestionSet quiz)
    {
        GameObject quizButton = Instantiate(prefab);

        quizButton.GetComponent<QuizButtonController>().SetQuiz(quiz);

        quizButton.GetComponentInChildren<TextMeshProUGUI>().SetText(quiz.Name);

        return quizButton;
    }
}
