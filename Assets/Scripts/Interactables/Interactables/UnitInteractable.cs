using System;
using UnityEngine;

public class UnitInteractable : BaseInteractable
{
    [SerializeField] private BaseUnit unit;
    [SerializeField] private bool moveDoneThisRound;

    [SerializeField]private MapObjectInteractable unitPlaced;

    public MapObjectInteractable UnitPlaced
    {
        get => unitPlaced;
        set => unitPlaced = value;
    }

    private int _moves;
    public override void Interact()
    {
        
    }

    private void Start()
    {
        TurnManager.Instance.OnTurnChanged += ChangeTurn;
    }

    private void ChangeTurn(TurnStates newturn)
    {
        switch (newturn)
        {
            case TurnStates.PlayerTurn:
                InitMoves();
                break;
            case TurnStates.AITurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newturn), newturn, null);
        }
    }

    public void ChangeMoves(int moves = 1)
    {
        _moves = Math.Max(0, _moves - moves);
    }

    public bool CanMove()
    {
        return _moves > 0;
    }

    private void InitMoves()
    {
        //_moves = количество ходов у юнита
    }
}
