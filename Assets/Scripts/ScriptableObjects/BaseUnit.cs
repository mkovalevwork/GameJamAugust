using UnityEngine;

public abstract class BaseUnit : ScriptableObject
{
    [SerializeField] private string objectName;
    [SerializeField] private GameObject prefabPrefab;

    public abstract void Use();
}
