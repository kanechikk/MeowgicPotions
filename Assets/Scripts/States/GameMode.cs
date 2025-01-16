using UnityEngine;

public class GameMode : MonoBehaviour
{
    private StateActivator m_stateActivator;
    private void Awake()
    {
        m_stateActivator = new StateActivator();
    }

    private void Start()
    {
        var states = GetComponentsInChildren<IGameState>(true);
        foreach (var state in states)
        {
            m_stateActivator.Add(state);
        }

        //m_stateActivator.Add(new PauseState());

        m_stateActivator.Activate<WalkingState>();
    }

    private void OnDestroy()
    {
        m_stateActivator.current.Deactivate();
        m_stateActivator.current.Exit();
    }

    public void Back()
    {
        m_stateActivator.Back();
    }

    public void GoToBrewing()
    {
        m_stateActivator.Activate<WalkingState>();
    }

    public void GoToPotionBook()
    {
        m_stateActivator.Push<PotionBookState>();
    }

    public void GoToInventory()
    {
        m_stateActivator.Activate<InventoryState>();
    }

    public void GoToShopping()
    {
        m_stateActivator.Activate<ShoppingState>();
    }
}
