using UnityEngine;

[CreateAssetMenu]
public class Category : ScriptableObject
{
    public string Name;

    [TextArea(2,5)]
    public string Description;
}
