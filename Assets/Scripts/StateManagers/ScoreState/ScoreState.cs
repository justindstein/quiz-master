using UnityEngine;

[CreateAssetMenu]
public class ScoreState : ScriptableObject
{
    // TODO: this might go elsewhere
    // TODO: IntVariable conversion
    public int QuestionCount = 0;

    public int CorrectAnswers = 0;

    public int IncorrectAnswers = 0;

    public void ResetScore()
    {
        this.QuestionCount = 0;
        this.CorrectAnswers = 0;
        this.IncorrectAnswers = 0;
    }

    // TODO: figure out if this is called by anything outside of ScoreController.UpdateScore, if not, all of the fields should be parameterized,
    // no reason to pass these globally?
    public string GetScore()
    {
        return string.Format("Score: {0} / {1}", this.CorrectAnswers, (this.CorrectAnswers + this.IncorrectAnswers));
    }
}
