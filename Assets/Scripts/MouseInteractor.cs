using System.Collections;
using UnityEngine;

public class MouseInteractor : MonoBehaviour
{
    [Header("Speed of move object")]
    [SerializeField] private float speed;
    [Header("Reference to DOMOVE button")]
    [SerializeField] private DoMoveBtnUI doMoveBtn;

    private MapObjectInteractable firstMapObject;
    private MapObjectInteractable secondMapObject;
    
    private void Update()
    {
        InputChecker();
    }

    private void InputChecker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (firstMapObject == null)
                SelectFirst();
            else
                SelectSecond();           
        }
    }

    private void SelectFirst()
    {     
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hit.collider.TryGetComponent(out MapObjectInteractable target);
            if (target == null) return;
            firstMapObject = target;
        }
    }

    private void SelectSecond()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hit.collider.TryGetComponent(out MapObjectInteractable target);
            if (target == null) return;
            if (ArrayContains(firstMapObject.NearMapObjects, target))
              
                secondMapObject = target;                      
        }
        doMoveBtn.gameObject.SetActive(true);        
    }

    private bool ArrayContains(BaseInteractable[] array, BaseInteractable target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target) return true;            
        }
        return false;
    }
   
    public void DoMove()
    {
        Transform var1 = firstMapObject.ActiveUnit.transform;
        Vector3 var2 = firstMapObject.transform.position;
        Vector3 var3 = secondMapObject.transform.position;

        GameObject activeUnit = firstMapObject.ActiveUnit;
        secondMapObject.setActiveUnit(activeUnit);
        firstMapObject.setActiveUnit(null);      
          
        StartCoroutine(MoveFromTo(var1, var2, var3, speed));
        ClearSelected();
    }
   
    private IEnumerator MoveFromTo(Transform objectToMove, Vector3 pos1, Vector3 pos2, float speed)
    {     
        float step = (speed / (pos1 - pos2).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            objectToMove.position = Vector3.Lerp(pos1, pos2, t); // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        objectToMove.position = pos2;
    }

    public void ClearSelected()
    {
        firstMapObject = null;
        secondMapObject = null;
    }
}
