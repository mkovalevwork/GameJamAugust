using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Swordman,
    Spearman,
    Horseman
};
[CreateAssetMenu(menuName = "Create Unit", fileName = "New Unit")]
public class UnitData : ScriptableObject
{
    [SerializeField] private UnitType _unitType;
    [SerializeField] private UnitType _killUnit;
    [SerializeField] private byte _moves;
    [SerializeField] private byte _damage;

    [SerializeField] private GameObject _unitPrefab;
    

}
