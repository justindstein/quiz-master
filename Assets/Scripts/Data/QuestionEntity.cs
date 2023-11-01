using System.Collections.Generic;

public class QuestionEntity
{
    public string Question { get; }

    public string Explanation { get; }

    public IList<ActiveAnswer> Answers { get; }

    public ActiveAnswer CorrectAnswer { get; }

    public QuestionEntity(Question question)
    {
        this.Question = question.QuestionText;
        this.Explanation = question.Explanation;

        List<string> answers = new List<string>(question.IncorrectAnswers);
        answers.Shuffle();
        int correctAnswerIndex = answers.RandomInsert(question.CorrectAnswer);

        this.Answers = new List<ActiveAnswer>();
        for (int i = 0; i < answers.Count; i++)
        {
            this.Answers.Add(new ActiveAnswer(answers[i], (i == correctAnswerIndex)));
        }

        this.CorrectAnswer = this.Answers[correctAnswerIndex];
    }

    public class ActiveAnswer
    {
        public string Answer;
        public bool IsCorrect;

        public ActiveAnswer(string answer, bool isCorrect)
        {
            this.Answer = answer;
            this.IsCorrect = isCorrect;
        }
    }
}