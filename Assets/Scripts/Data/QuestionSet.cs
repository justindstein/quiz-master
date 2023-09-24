using UnityEngine;

[CreateAssetMenu]
// TODO: rename to quiz type
public class QuestionSet : ScriptableObject
{
    public string Name;

    [TextArea(2, 5)]
    public string Description;

    public Question[] Questions;
}
