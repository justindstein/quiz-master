using UnityEngine;

[CreateAssetMenu]
public class ScoreState : ScriptableObject
{
    // TODO: this might go elsewhere
    // TODO: IntVariable conversion
    public int QuestionCount;

    public int CorrectAnswers;

    public int IncorrectAnswers;

    // Reset values as ScripableObject.Awake does not run as expected:
    // https://forum.unity.com/threads/solved-but-unhappy-scriptableobject-awake-never-execute.488468/
    private void OnEnable()
    {
        this.QuestionCount = 0;
        this.CorrectAnswers = 0;
        this.IncorrectAnswers = 0;
    }

    public string GetScore()
    {
        return string.Format("Score: {0} / {1}", this.CorrectAnswers, (this.CorrectAnswers + this.IncorrectAnswers));
    }
}
