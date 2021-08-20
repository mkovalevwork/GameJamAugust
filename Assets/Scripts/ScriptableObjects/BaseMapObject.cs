using UnityEngine;

public abstract class BaseMapObject : ScriptableObject
{
    [SerializeField] private string objectName;
    [SerializeField] private GameObject prefabPrefab;

    public abstract void Use();
}
