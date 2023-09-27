using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuizController : MonoBehaviour
{
    public GameObject QuizButtonPrefab;

    public QuestionSet[] Quizzes;

    public GameEvent OnLoadMenu;

    public UnityEvent OnQuizStarted;

    // TODO: This should be moved elsewhere
    private void Start()
    {
        this.OnLoadMenu.Raise();
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
    /// Clears out all loaded quizzes
    /// </summary>
    /// TODO: 
    public void ClearQuizzes()
    {
        //for (int i = this.transform.childCount - 1; i >= 0; i--)
        //{
        //    Destroy(this.transform.GetChild(i).gameObject);
        //}
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
