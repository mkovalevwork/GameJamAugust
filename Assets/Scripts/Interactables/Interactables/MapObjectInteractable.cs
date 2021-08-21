using UnityEngine;

public class MapObjectInteractable : BaseInteractable
{

    [SerializeField] private BaseMapObject mapObject;
    [SerializeField] private BaseInteractable[] nearMapObjects;
    public BaseInteractable[] NearMapObjects => nearMapObjects;

    [SerializeField] private GameObject activeUnit;
    public GameObject ActiveUnit => activeUnit;

    public void setActiveUnit(GameObject unitInteractable)
    {
        activeUnit = unitInteractable;
    }

    public override void Interact()
    {
    }

    private void OnDrawGizmosSelected()
    {
        foreach (BaseInteractable item in nearMapObjects)
        {
            if (item == null) continue;                     
            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position, item.transform.position);
        }
    }
}
