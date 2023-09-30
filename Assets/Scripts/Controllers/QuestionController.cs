using TMPro;
using UnityEngine;

using static QuizStateManager;

public class QuestionController : MonoBehaviour
{
    public GameObject QuestionTextPrefab;

    public StringVariable CorrectAnswerText;

    public StringVariable IncorrectAnswerText;

    public StringVariable ExpiredTimerText;

    public void ShowQuestion(Component component, System.Object obj)
    {
        if (obj is QuestionPresentation questionPresentation)
        {
            // Clear out previous question
            this.deleteQuestions();

            // Instantiate a question
            GameObject questionText = instantiateQuestionText(this.QuestionTextPrefab, questionPresentation.Question);

            // Set its parent to 'Question' GameObject
            questionText.transform.SetParent(this.transform);
        }
    }

    public void ShowCorrectAnswerText(Component component, System.Object obj)
    {
        // Clear out previous question
        this.deleteQuestions();

        // Instantiate a question
        GameObject questionText = instantiateQuestionText(this.QuestionTextPrefab, this.CorrectAnswerText.Value);

        // Set its parent to 'Question' GameObject
        questionText.transform.SetParent(this.transform);
    }

    public void ShowIncorrectAnswerText(Component component, System.Object obj)
    {
        if (obj is QuestionPresentation questionPresentation)
        {
            // Clear out previous question
            this.deleteQuestions();

            // Instantiate a question
            GameObject questionText = instantiateQuestionText(this.QuestionTextPrefab, string.Format(this.IncorrectAnswerText.Value, questionPresentation.Answers[questionPresentation.CorrectAnswerIndex]));

            // Set its parent to 'Question' GameObject
            questionText.transform.SetParent(this.transform);

        }
    }

    public void ShowTimerExpiredText(Component component, System.Object obj)
    {
        if (obj is QuestionPresentation questionPresentation)
        {
            // Clear out previous question
            this.deleteQuestions();

            // Instantiate a question
            GameObject questionText = instantiateQuestionText(this.QuestionTextPrefab, string.Format(this.ExpiredTimerText.Value, questionPresentation.Answers[questionPresentation.CorrectAnswerIndex]));

            // Set its parent to 'Question' GameObject
            questionText.transform.SetParent(this.transform);
        }
    }

    private GameObject instantiateQuestionText(GameObject prefab, string text)
    {
        GameObject questionText = Instantiate(prefab);

        questionText.GetComponent<TextMeshProUGUI>().SetText(text);

        return questionText;
    }

    private void deleteQuestions()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}
