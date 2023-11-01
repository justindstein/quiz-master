using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public GameObject QuestionTextPrefab;

    public StringVariable CorrectAnswerText;

    public StringVariable IncorrectAnswerText;

    public StringVariable ExpiredTimerText;

    public void ShowQuestion(Component component, System.Object obj)
    {
        if (obj is QuestionEntity questionPresentation)
        {
            // Clear out previous question
            this.DeleteQuestions(null, null);

            // Instantiate a question
            GameObject questionText = instantiateQuestionText(this.QuestionTextPrefab, questionPresentation.Question);

            // Set its parent to 'Question' GameObject
            questionText.transform.SetParent(this.transform);
        }
    }

    public void ShowCorrectAnswerText(Component component, System.Object obj)
    {
        if (obj is QuestionEntity question)
        {
            // Clear out previous question
            this.DeleteQuestions(null, null);

            // Instantiate a question
            GameObject questionText = instantiateQuestionText(this.QuestionTextPrefab, string.Format(this.CorrectAnswerText.Value, question.AnswerExplanation));

            // Set its parent to 'Question' GameObject
            questionText.transform.SetParent(this.transform);
        }
    }

    public void ShowIncorrectAnswerText(Component component, System.Object obj)
    {
        if (obj is QuestionEntity question)
        {
            // Clear out previous question
            this.DeleteQuestions(null, null);

            // Instantiate a question
            GameObject questionText = instantiateQuestionText(this.QuestionTextPrefab, string.Format(this.IncorrectAnswerText.Value, question.CorrectAnswer.Answer));

            // Set its parent to 'Question' GameObject
            questionText.transform.SetParent(this.transform);
        }
    }

    public void ShowTimerExpiredText(Component component, System.Object obj)
    {
        if (obj is QuestionEntity question)
        {
            // Clear out previous question
            this.DeleteQuestions(null, null);

            // Instantiate a question
            GameObject questionText = instantiateQuestionText(this.QuestionTextPrefab, string.Format(this.ExpiredTimerText.Value, question.CorrectAnswer.Answer));

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

    public void DeleteQuestions(Component component, System.Object obj)
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}
