using System;
using System.Collections.Generic;

public class QuestionEntity
{
    public string Question { get; }

    public string AnswerExplanation { get; }

    public IList<AnswerEntity> AnswerEntities { get; }

    public AnswerEntity CorrectAnswer { get; }

    public QuestionEntity(Question question)
    {
        this.Question = question.Text;
        this.AnswerExplanation = question.AnswerExplanation;

        List<string> answers = new List<string>(question.IncorrectAnswers);
        answers.Shuffle();
        int correctAnswerIndex = answers.RandomInsert(question.CorrectAnswer);

        this.AnswerEntities = new List<AnswerEntity>();
        for (int i = 0; i < answers.Count; i++)
        {
            this.AnswerEntities.Add(new AnswerEntity(answers[i], (i == correctAnswerIndex)));
        }

        this.CorrectAnswer = this.AnswerEntities[correctAnswerIndex];
    }
}