using UnityEngine;

public interface IGameState
{
    void Enter();
    void Exit();
    void Walking();
    void Brewing();
    void PotionBook();
    void Shop();
    void Inventory();
    void Sleep();
}
