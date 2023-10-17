using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameObject ScoreTextPrefab;

    private TextMeshProUGUI scoreText;

    private int questionCount = 0;

    private int correctAnswers = 0;

    public void CreateScore(Component component, System.Object obj)
    {
        this.DestroyScores();

        GameObject scoreObject = Instantiate(this.ScoreTextPrefab);
        this.scoreText = scoreObject.GetComponent<TextMeshProUGUI>();

        this.ResetScore();
        this.scoreText.SetText(this.GetScore());

        this.scoreText.transform.SetParent(this.transform);
    }

    public void DestroyScores()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    public void IncrementCorrectAnswers()
    {
        this.questionCount++;
        this.correctAnswers++;
        this.scoreText.SetText(this.GetScore());
    }

    public void IncrementIncorrectAnswers()
    {
        this.questionCount++;
        this.scoreText.SetText(this.GetScore());
    }

    private void ResetScore()
    {
        this.questionCount = 0;
        this.correctAnswers = 0;
    }

    private string GetScore()
    {
        return string.Format("Score: {0} / {1}", this.correctAnswers, this.questionCount);
    }
}