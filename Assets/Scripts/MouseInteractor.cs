using System;
using System.Collections;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;

public class MouseInteractor : MonoBehaviour
{
    [Header("Speed of move object")]
    [SerializeField] private float speed;
    [Header("Reference to DOMOVE button")]
    [SerializeField] private DoMoveBtnUI doMoveBtn;
    [SerializeField] private BattleSystem battleSystem;

    private MapObjectInteractable firstMapObject;
    private MapObjectInteractable secondMapObject;

    private UnitInteractable _selectedUnit;
    private MapObjectInteractable _selectedMapObject;
    

    private void Update()
    {
        //Если ход противника, заблокировать управление
        if(!TurnManager.Instance.isPlayerTurn()) 
            return;
        //InputChecker();
        if (Input.GetMouseButtonDown(0))
        {
            CheckSelection();
        }
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

    private void CheckSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            string selectedObjectTag = hit.collider.gameObject.tag;
            switch (selectedObjectTag)
            {
                case "PlayerUnit":
                    hit.collider.TryGetComponent(out UnitInteractable selectedUnit);
                    if (selectedUnit)
                        _selectedUnit = selectedUnit;
                    Debug.Log("Selected unit"+ _selectedUnit.gameObject.name);
                    break;
                case "MapObject":
                    hit.collider.TryGetComponent(out MapObjectInteractable selectedMapObject);
                    if (selectedMapObject)
                    {
                         _selectedMapObject = selectedMapObject;
                         if (_selectedUnit && _selectedMapObject.NearMapObjects.Contains(_selectedUnit.UnitPlaced))
                         {
                             if(_selectedMapObject.ActiveUnit && _selectedMapObject.ActiveUnit.gameObject.CompareTag("PlayerUnit"))
                                 return;
                             if(_selectedUnit.CanMove())
                                DoMove();
                            

                         }
                    }
                       
                    
                    if(_selectedMapObject != null && _selectedUnit != null)
                    Debug.Log("Selected node"+ _selectedMapObject.gameObject.name);
                    break;
                default:
                    break;
            }
           
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
        /*if (secondMapObject.ActiveUnit)
        {
            bool result = battleSystem.Fight(firstMapObject.ActiveUnit, secondMapObject.ActiveUnit);
            if (result)
            {
                Destroy(secondMapObject.ActiveUnit);
                secondMapObject.setActiveUnit(null);
            }
            if (!result)
            {

            }
        }*/

        Transform var1 =_selectedUnit.transform;
        Vector3 var2 = _selectedUnit.UnitPlaced.transform.position;
        Vector3 var3 = _selectedMapObject.transform.position;

        StartCoroutine(MoveFromTo(var1, var2, var3, speed));
        //StartCoroutine(waitForMove());
        Debug.Log("End");
        _selectedUnit.ChangeMoves(1);
        _selectedMapObject.ActiveUnit = _selectedUnit.gameObject;
        _selectedUnit.UnitPlaced.ActiveUnit = null;
        _selectedUnit.UnitPlaced = _selectedMapObject;
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

    private IEnumerator waitForMove()
    {
        Debug.Log("Start");
        bool moveDone = (firstMapObject.ActiveUnit.transform.position == secondMapObject.transform.position);
        yield return new WaitUntil(() => moveDone);
    }

    public void ClearSelected()
    {
        _selectedUnit = null;
        _selectedMapObject = null;
    }
}
