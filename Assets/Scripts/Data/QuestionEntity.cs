using System.Collections.Generic;

public class QuestionEntity
{
    public string Question { get; }

    public string Explanation { get; }

    public List<string> Answers { get; }

    public string CorrectAnswer { get; }

    public QuestionEntity(Question question)
    {
        this.Question = question.QuestionText;
        this.Explanation = question.Explanation;

        List<string> answers = new List<string>(question.IncorrectAnswers);
        answers.Shuffle();
        int correctAnswerIndex = answers.RandomInsert(question.CorrectAnswer);

        this.Answers = new List<string>(answers);
        this.CorrectAnswer = this.Answers[correctAnswerIndex];
    }
}
