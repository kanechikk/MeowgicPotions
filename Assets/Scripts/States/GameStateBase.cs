using UnityEngine;

public abstract class GameStateBase : MonoBehaviour, IGameState
{
    public virtual void Brewing()
    {
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Inventory()
    {
    }

    public virtual void PotionBook()
    {
    }

    public virtual void Shop()
    {
    }

    public virtual void Sleep()
    {
    }

    public virtual void Walking()
    {
    }
}
