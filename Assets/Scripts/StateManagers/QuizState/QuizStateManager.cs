using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuizStateManager : MonoBehaviour
{
    public UnityEvent<Component, System.Object> OnQuizLoaded;

    public UnityEvent<Component, QuestionPresentation> OnQuestionLoaded;

    public UnityEvent<Component, System.Object> OnQuizFinished;

    private readonly IList<Question> askedQuestions = new List<Question>();

    private readonly Queue<Question> unaskedQuestions = new Queue<Question>();

    private void OnDisable()
    {
        this.askedQuestions.Clear();
        this.unaskedQuestions.Clear();
    }

    /// <summary>
    /// Loads the quiz.
    /// </summary>
    /// <param name="component"></param>
    /// <param name="obj"></param>
    public void SetQuiz(Component component, System.Object obj)
    {
        if (obj is QuestionSet quiz)
        {
            this.askedQuestions.Clear();

            this.unaskedQuestions.Clear();
            this.unaskedQuestions.AddRange(((IList<Question>)new List<Question>())
                .AddRange(quiz.Questions)
                .Shuffle()
            );

            OnQuizLoaded.Invoke(this, quiz); // TODO: passing quizName not necessary 
        }
    }

    // TODO: QuizStateManager should maybe just load all quizzes and store
    public void LoadQuestion()
    {
        if (this.unaskedQuestions.Count > 0)
        {
            Question nextQuestion = this.unaskedQuestions.Dequeue();
            this.askedQuestions.Add(nextQuestion);
            this.OnQuestionLoaded.Invoke(this, new QuestionPresentation(nextQuestion)); // TODO: clean up questionPresentation
        }
        else
        {
            this.OnQuizFinished.Invoke(this, null);
        }
    }

    // TODO: implement this structure
    // Quizzes -> [quiz1, quiz2, etc]
    // Quiz1 -> [question1, question2, etc]
    // Question1 -> {question {questionText, answeredText}, answers[] {answer1 {text, isCorrectAnswer}, answer2, answer3, answer4} }
    // Start is called before the first frame update
    public class QuestionPresentation
    {
        public string Question { get; }

        public string AnswerExplanation { get; }

        public IList<AnswerEntity> AnswerEntities { get; }

        public AnswerEntity CorrectAnswer { get; }

        public QuestionPresentation(Question question)
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