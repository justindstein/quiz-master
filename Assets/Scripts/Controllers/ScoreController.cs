using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // TODO: should this be merged with ScoreState?
    // TODO: Deserialize things that are not used externally
    public GameObject ScoreTextPrefab;

    //public TextMeshProUGUI ScoreText;

    //public QuizStateManager QuizStateManager;

    //public ScoreState ScoreState;

    private void Start()
    {
        //this.ScoreState.QuestionCount = this.QuizStateManager.GetQuestionCount(); // TODO: is this necessary?
        //this.UpdateScore();
    }

    public void ShowScore(Component component, System.Object obj)
    {
        //this.ScoreText.text = this.ScoreState.GetScore();
        //this.ScoreText.text = "1337 / 1337";
    }

    //public void IncrementCorrectAnswers()
    //{
    //    this.ScoreState.CorrectAnswers++;
    //}

    //public void IncrementIncorrectAnswers()
    //{
    //    this.ScoreState.IncorrectAnswers++;
    //}

    //public void UpdateScore()
    //{
    //    this.ScoreText.text = this.ScoreState.GetScore();
    //}
}