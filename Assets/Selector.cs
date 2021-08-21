using System;
using UnityEngine;

public delegate void OnSelectUnit(BaseEntity unit);

public delegate void OnSelectPlattform(WalkablePlattform plattform);

public class Selector : MonoBehaviour
{
    //Selected Unit
    private BaseEntity selectEntity;
    
    //Selected Waypoint
    private WalkablePlattform selectedPlattform;

    public OnSelectUnit onSelectUnit;
    public OnSelectPlattform onSelectPlattform;

#if UNITY_EDITOR
    public BaseEntity debug_selectedEntity;
    public WalkablePlattform debug_selectedPlattform;
#endif
    
    private void OnEnable()
    {
        onSelectUnit += SelectUnit;
        onSelectPlattform += SelectPlattform;
    }

    private void OnDisable()
    {
        onSelectUnit -= SelectUnit;
        onSelectPlattform -= SelectPlattform;
    }

#if UNITY_EDITOR
    private void Update()
    {
        debug_selectedEntity = selectEntity;
        debug_selectedPlattform = selectedPlattform;
    }
#endif
    
    // TODO - Complete Select Unit Function
    public void SelectUnit(BaseEntity unit)
    {
        // Select Unit

        // Select Plattform under Unit
    }

    public void SelectPlattform(WalkablePlattform plattform)
    {
        // Select Plattform
        selectedPlattform = plattform;
        
        // Select Unit
        selectEntity = selectedPlattform.ActiveUnit 
            ? selectedPlattform.ActiveUnit.GetComponent<BaseEntity>()
            : null;
    }
}