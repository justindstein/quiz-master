using UnityEngine;

[CreateAssetMenu]
public class StringVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public string Value;

    public void SetValue(string value)
    {
        Value = value;
    }

    public void SetValue(StringVariable value)
    {
        Value = value.Value;
    }
}