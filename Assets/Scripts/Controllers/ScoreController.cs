using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameObject ScoreTextPrefab;

    public StringVariable ScoreText;

    public IntVariable LifetimeAnswerCount;

    public IntVariable LifetimeCorrectAnswerCount;

    public IntVariable QuizAnswerCount;
     
    public IntVariable QuizCorrectAnswerCount;

    private TextMeshProUGUI scoreText;

    public void CreateScore(Component component, System.Object obj)
    {
        this.DestroyScores();

        this.QuizAnswerCount.SetValue(0);
        this.QuizCorrectAnswerCount.SetValue(0);

        GameObject scoreObject = Instantiate(this.ScoreTextPrefab);
        this.scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        this.scoreText.transform.SetParent(this.transform);

        this.UpdateScore();
    }

    public void DestroyScores(Component component, System.Object obj)
    {
        this.DestroyScores();
    }

    private void DestroyScores()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    public void IncrementCorrectAnswers()
    {
        this.QuizAnswerCount.ApplyChange(1);
        this.QuizCorrectAnswerCount.ApplyChange(1);

        this.LifetimeAnswerCount.ApplyChange(1);
        this.LifetimeCorrectAnswerCount.ApplyChange(1);

        this.UpdateScore();
    }

    public void IncrementIncorrectAnswers()
    {
        this.QuizAnswerCount.ApplyChange(1);
        this.LifetimeAnswerCount.ApplyChange(1);

        this.UpdateScore();
    }

    public void UpdateScore()
    {
        this.scoreText.SetText(string.Format(this.ScoreText.Value, this.QuizCorrectAnswerCount.Value, this.QuizAnswerCount.Value));
    }
}
