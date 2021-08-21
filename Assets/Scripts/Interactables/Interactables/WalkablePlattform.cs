using UnityEngine;

public class WalkablePlattform : BasePlattform
{
    [SerializeField] private GameObject activeUnit;
    public GameObject ActiveUnit => activeUnit;

    public void setActiveUnit(GameObject unitInteractable)
    {
        activeUnit = unitInteractable;
    }
    
    // TODO - Complete OnMouseDown Logic to Move towards the destination
    private void OnMouseDown()
    {
        Selector?.onSelectPlattform(this);
    }
}