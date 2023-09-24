using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// TODO: Let's start with StateManagers and transition to State if possible

public class QuizStateManager : MonoBehaviour
{
    // TODO: is questionSet necessary? Possibly
    private QuestionSet questionSet;

    private IList<Question> askedQuestions = new List<Question>();

    // TODO: Convert to queue
    private IList<Question> unaskedQuestions = new List<Question>();
    private Queue<Question> unaskedQuestionsQueue = new Queue<Question>();

    List<QuestionState> questionStates = new List<QuestionState>();

    public UnityEvent OnQuizStarted;

    public UnityEvent OnLoadQuestion;

    // TODO: convert to set of questions
    public void StartQuiz(QuestionSet questionSet)
    {
        this.OnQuizStarted.Invoke();

        this.questionSet = questionSet;

        this.askedQuestions.Clear();

        this.unaskedQuestions.Clear();
        this.unaskedQuestions.AddRange(questionSet.Questions).Shuffle().ToQueue();
        this.unaskedQuestionsQueue = unaskedQuestions.ToQueue();

        this.LoadNextQuestion();
    }

    /// <summary>
    /// TODO: Returns true if correct answer
    /// </summary>
    /// <param name="question"></param>
    /// <param name="answeredIndex"></param>
    /// <returns></returns>
    public bool SubmitAnswer(QuestionPresentation questionPresentation, int answeredIndex)
    {
        QuestionState questionState = new QuestionState(questionPresentation, answeredIndex);
        this.questionStates.Add(questionState);
        return (questionState.AnsweredIndex == questionPresentation.CorrectAnswerIndex);
    }

    public void LoadNextQuestion()
    {
        this.questionPresentation = new QuestionPresentation(this.GetNextQuestion());
        this.OnLoadQuestion.Invoke();
    }

    private Question GetNextQuestion()
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

    private QuestionPresentation questionPresentation;

    public string GetQuestion()
    {
        return this.questionPresentation.Question;
    }

    public IList<string> GetAnswers()
    {
        return this.questionPresentation.Answers;
    }

    public int GetCorrectAnswerIndex()
    {
        return this.questionPresentation.CorrectAnswerIndex;
    }

    public string GetCorrectAnswer()
    {
        return this.GetAnswers()[this.GetCorrectAnswerIndex()];
    }

    public IList<AnswerEntity> GetAnswerEntities()
    {
        return this.questionPresentation.AnswerEntities;
    }

    // TODO:
    // Store each QuestionPresentation for review at the end of the quiz
    // record the answer that was made and whether it was correct or incorrect

    // TODO: implement this structure
    // Quizzes -> [quiz1, quiz2, etc]
    // Quiz1 -> [question1, question2, etc]
    // Question1 -> {question {questionText, answeredText}, answers[] {answer1 {text, isCorrectAnswer}, answer2, answer3, answer4} }
    // Start is called before the first frame update
    public class QuestionPresentation
    {
        public string Question { get; }

        public IList<string> Answers { get; }

        public int CorrectAnswerIndex { get; }

        public IList<AnswerEntity> AnswerEntities;

        // TODO: clean up this mess
        public QuestionPresentation(Question question)
        {
            this.Question = question.Text;

            List<string> answers = new List<string>(question.IncorrectAnswers);
            this.Answers = answers.Shuffle();

            this.CorrectAnswerIndex = answers.RandomInsert(question.CorrectAnswer);

            this.AnswerEntities = new List<AnswerEntity>();
            for (int i = this.Answers.Count - 1; i >= 0; i--)
            {
                AnswerEntity answer = new AnswerEntity(this.Answers[i], (i == this.CorrectAnswerIndex));
                this.AnswerEntities.Add(answer);
            }
        }
    }

    private class QuestionState
    {
        public QuestionPresentation QuestionPresentation;
        public int AnsweredIndex;

        public QuestionState(QuestionPresentation questionPresentation, int answeredIndex)
        {
            this.QuestionPresentation = questionPresentation;
            this.AnsweredIndex = answeredIndex;
        }
    }

    public class AnswerEntity
    {
        public string Answer;
        public bool IsCorrect;

        public AnswerEntity(string answer, bool isCorrect)
        {
            this.Answer = answer;
            this.IsCorrect = isCorrect;
        }
    }
}