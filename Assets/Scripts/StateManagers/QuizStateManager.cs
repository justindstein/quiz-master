using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

// TODO: Let's start with StateManagers and transition to State if possible
// QuestionManager? QuizManager?
public class QuizStateManager : MonoBehaviour
{
    //public UnityEvent OnQuizStarted;

    //public UnityEvent OnQuizEnded;

    //public UnityEvent OnLoadQuestion;

    private IList<Question> askedQuestions;

    private Queue<Question> unaskedQuestions;

    private void Awake()
    {
        this.askedQuestions = new List<Question>();
        this.unaskedQuestions = new Queue<Question>();
    }

    // TODO: convert to set of questions
    public void StartQuiz(QuestionSet questionSet)
    {
        //this.OnQuizStarted.Invoke();

        this.askedQuestions.Clear();

        this.unaskedQuestions.Clear();
        this.unaskedQuestions = ((IList<Question>)new List<Question>())
            .AddRange(questionSet.Questions)
            .Shuffle()
            .ToQueue();

        //this.LoadNextQuestion();
    }

    // TODO: QuizStateManager should maybe just load all quizzes and store
    public void LoadNextQuestion()
    {
        Question nextQuestion = this.unaskedQuestions.Dequeue();
        this.askedQuestions.Add(nextQuestion);
        this.questionPresentation = new QuestionPresentation(nextQuestion);

        //this.OnLoadQuestion.Invoke();
    }

    public bool IsQuestionRemaining()
    {
        return (this.unaskedQuestions.Count > 0);
    }

    public int GetQuestionCount()
    {
        return this.askedQuestions.Count + this.unaskedQuestions.Count;
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

    // TODO: maybe this should just be wrapped up in GetCurrentQuestion, it's retrieved once and stored locally. It's weird for there
    // to be a current question in this service
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