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

    [TextArea(2, 6)]
    public string Explanation;

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
        this.Explanation = explanation;
    }
}
