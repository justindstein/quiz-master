using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // TODO: should this be merged with ScoreState?
    // TODO: Deserialize things that are not used externally
    public TextMeshProUGUI ScoreText;

    public QuestionSetManager QuestionSetManager;

    public ScoreState ScoreState;

    private void Start()
    {
        //this.QuestionSetManager.GetNextQuestion();
        this.ScoreState.QuestionCount = this.QuestionSetManager.GetQuestionCount();
        this.UpdateScore();
    }

    public void IncrementCorrectAnswers()
    {
        this.ScoreState.CorrectAnswers++;
    }

    public void IncrementIncorrectAnswers()
    {
        this.ScoreState.IncorrectAnswers++;
    }

    public void UpdateScore()
    {
        this.ScoreText.text = this.ScoreState.GetScore();
    }
}