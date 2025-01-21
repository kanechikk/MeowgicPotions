using UnityEngine;

public interface IGameState
{
    void Enter();
    void Exit();
    void Activate();
    void Deactivate();
}
