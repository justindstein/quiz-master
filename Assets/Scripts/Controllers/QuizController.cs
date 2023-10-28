using TMPro;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    public GameObject QuizButtonPrefab;

    public Quiz[] Quizzes;

    /// <summary>
    /// Load a collection of quizzes into 'Quizzes' layout group
    /// </summary>
    public void LoadQuizzes(Component component, System.Object obj)
    {
        foreach (Quiz quiz in this.Quizzes)
        {
            // Instantiate a button
            GameObject quizButton = instantiateQuizButton(this.QuizButtonPrefab, quiz);

            // Set its parent to 'Answers' GameObject
            quizButton.transform.SetParent(this.transform);
        }
    }

    public void DestroyQuizzes(Component component, System.Object obj)
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// Instantiates a new quiz button
    /// </summary>
    /// <param name="prefab">The prefab to instantiate</param>
    /// <param name="quiz">The associated quiz</param>
    /// <returns>Instantiated button gameobject</returns>
    private GameObject instantiateQuizButton(GameObject prefab, Quiz quiz)
    {
        GameObject quizButton = Instantiate(prefab);

        quizButton.GetComponent<QuizButtonController>().SetQuiz(quiz);

        quizButton.GetComponentInChildren<TextMeshProUGUI>().SetText(quiz.Name);

        return quizButton;
    }
}