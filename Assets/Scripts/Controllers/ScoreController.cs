using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // TODO: should this be merged with ScoreState?
    // TODO: Deserialize things that are not used externally
    public GameObject ScoreTextPrefab;

    public ScoreState ScoreState;

    private TextMeshProUGUI scoreText;

    public void CreateScore(Component component, System.Object obj)
    {
        this.DestroyScores(null, null);

        GameObject scoreObject = Instantiate(this.ScoreTextPrefab);
        this.scoreText = scoreObject.GetComponent<TextMeshProUGUI>();

        this.ScoreState.ResetScore();
        this.scoreText.SetText(this.ScoreState.GetScore());

        this.scoreText.transform.SetParent(this.transform);
    }

    public void DestroyScores(Component component, System.Object obj)
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    public void IncrementCorrectAnswers()
    {
        this.ScoreState.CorrectAnswers++;
        this.scoreText.SetText(this.ScoreState.GetScore());
    }

    public void IncrementIncorrectAnswers()
    {
        this.ScoreState.IncorrectAnswers++;
        this.scoreText.SetText(this.ScoreState.GetScore());
    }
}