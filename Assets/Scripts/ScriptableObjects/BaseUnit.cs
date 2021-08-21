using UnityEngine;

public enum UnitType
{
    Swordman,
    Spearman,
    Horseman
};

public abstract class BaseUnit : ScriptableObject
{
    [SerializeField] private UnitType _unitType;
    [SerializeField] private UnitType _killUnit;
    [SerializeField] private byte _moves;
    [SerializeField] private byte _damage;

    [SerializeField] private GameObject _unitPrefab;

    public abstract void Use();
    
}
