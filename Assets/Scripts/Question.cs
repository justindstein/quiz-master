using UnityEngine;

//[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
[CreateAssetMenu]
public class Question : ScriptableObject
{
    [TextArea(2, 6)]
    public string Value;

    public void SetValue(string value)
    {
        this.Value = value;
    }
}
