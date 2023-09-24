using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public GameObject QuizButtonPrefab;

    public QuizStateManager QuizStateManager;

    public QuestionSet[] Quizzes;

    private void Start()
    {
        this.loadAnswers();
    }

    private void loadAnswers()
    {
        foreach (QuestionSet quiz in this.Quizzes)
        {
            // Instantiate a button
            GameObject quizButton = instantiateAnswerButton(this.QuizButtonPrefab, quiz);

            // Set its parent to 'Answers' GameObject
            quizButton.transform.SetParent(this.transform);
        }
    }

    private GameObject instantiateAnswerButton(GameObject prefab, QuestionSet quiz)
    {
        GameObject quizButton = Instantiate(prefab);

        quizButton.GetComponent<QuizButtonController>().SetQuizStateManager(this.QuizStateManager);
        quizButton.GetComponent<QuizButtonController>().SetQuiz(quiz);

        //quizButton.GetComponent<Button>().onClick.AddListener(() =>
        //{
        //    quizButton.GetComponent<QuizButtonController>().OnClick();
        //});

        quizButton.GetComponentInChildren<TextMeshProUGUI>().SetText(quiz.Name);

        return quizButton;
    }
}
