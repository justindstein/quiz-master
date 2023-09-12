using UnityEngine;

//[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
[CreateAssetMenu]
public class Question : ScriptableObject
{
    [TextArea(2, 6)]
    public string Text;

    public Category Category;

    public string CorrectAnswer;

    public string[] IncorrectAnswers;

    public string[] Hints; // TODO: convert this to a stack at some point

    [TextArea(2, 6)]
    public string AnswerExplanation;

    public void SetQuestion(Question question)
    {
        this.Text = question.Text;
        this.Category = question.Category;
        this.CorrectAnswer = question.CorrectAnswer;
        this.IncorrectAnswers = question.IncorrectAnswers;
        this.AnswerExplanation = question.AnswerExplanation;
    }

    public void SetText(string text)
    {
        this.Text = text;
    }

    public void SetCategory(Category category)
    {
        this.Category = category;
    }

    public void SetCorrectAnswer(string correctAnswer)
    {
        this.CorrectAnswer = correctAnswer;
    }

    public void SetIncorrectAnswers(string[] incorrectAnswers)
    {
        this.IncorrectAnswers = incorrectAnswers;
    }

    public void SetExplanation(string explanation)
    {
        this.AnswerExplanation = explanation;
    }
}
