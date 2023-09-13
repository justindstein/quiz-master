using UnityEngine;

[CreateAssetMenu]
public class QuestionSet : ScriptableObject
{
    public string Name;

    [TextArea(2, 5)]
    public string Description;

    public Question[] Questions;
}
