using System.Collections.Generic;
using UnityEngine;

// TODO: Let's start with StateManagers and transition to State if possible

public class QuizStateManager : MonoBehaviour
{
    // TODO: is questionSet necessary? Possibly
    private QuestionSet questionSet;

    private IList<Question> askedQuestions = new List<Question>();

    // TODO: Convert to queue
    private IList<Question> unaskedQuestions = new List<Question>();
    //private Queue<Question> unaskedQuestions = new Queue<Question>();

    // TODO: convert to set of questions
    public void LoadQuestionSet(QuestionSet questionSet)
    {
        this.questionSet = questionSet;

        this.askedQuestions.Clear();

        this.unaskedQuestions.Clear();
        this.unaskedQuestions.AddRange(questionSet.Questions).Shuffle();

        this.LoadQuestion(this.GetNextQuestion());
    }

    public Question GetNextQuestion()
    {
        Question nextQuestion = this.unaskedQuestions[0];
        this.unaskedQuestions.RemoveAt(0);

        this.askedQuestions.Add(nextQuestion);

        return nextQuestion;
    }

    public int GetQuestionCount()
    {
        return this.askedQuestions.Count + this.unaskedQuestions.Count;
    }

    public bool IsQuestionRemaining()
    {
        return (this.GetQuestionCount() > 0);
    }


    //////////////


    private QuestionPresentation currentQuestion;

    public void LoadQuestion(Question question)
    {
        this.currentQuestion = new QuestionPresentation(question);
    }

    public string GetQuestion()
    {
        return this.currentQuestion.Question;
    }

    public IList<string> GetAnswers()
    {
        return this.currentQuestion.Answers;
    }

    public int GetCorrectAnswerIndex()
    {
        return this.currentQuestion.CorrectAnswerIndex;
    }

    public string GetCorrectAnswer()
    {
        return this.GetAnswers()[this.GetCorrectAnswerIndex()];
    }

    // TODO:
    // Store each QuestionPresentation for review at the end of the quiz
    // record the answer that was made and whether it was correct or incorrect

    // TODO: implement this structure
    // Quizzes -> [quiz1, quiz2, etc]
    // Quiz1 -> [question1, question2, etc]
    // Question1 -> {question {questionText, answeredText}, answers[] {answer1 {text, isCorrectAnswer}, answer2, answer3, answer4} }
    // Start is called before the first frame update
    private class QuestionPresentation
    {
        public string Question { get; }

        public IList<string> Answers { get; }

        public int CorrectAnswerIndex { get; }

        public QuestionPresentation(Question question)
        {
            this.Question = question.Text;

            List<string> answers = new List<string>(question.IncorrectAnswers);
            this.Answers = answers.Shuffle();

            this.CorrectAnswerIndex = answers.RandomInsert(question.CorrectAnswer);
        }
    }
}
