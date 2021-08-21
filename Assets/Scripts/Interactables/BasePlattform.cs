using UnityEngine;

public abstract class BasePlattform : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Selector selector;

    public Selector Selector => selector;
    
    [Space(10)]
    
    [Header("Destination Setup")]
    [SerializeField] private BasePlattform[] nextDestinations;
    public BasePlattform[] NextDestinations => nextDestinations;

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        foreach (BasePlattform item in nextDestinations)
        {
            if (item == null) continue;
            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position, item.transform.position);
        }
    }
#endif
}
