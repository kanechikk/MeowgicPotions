using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaeyrConroller : MonoBehaviour
{
    public Player player;
    public InputActionAsset inputActions;
    private InputAction m_moveAction;
    [SerializeField] private GameMode m_states;
    [SerializeField] private GameObject m_wateringState;
    [SerializeField] private RhythmCheck m_rhythmCheck;


    // Временный код для удобной проверки
    public GameObject inventoryState;

    private void Start()
    {
        var map = inputActions.FindActionMap("Player");
        map.Enable();

        m_moveAction = map.FindAction("Move");
    }

    private void Update()
    {
        Vector2 move = m_moveAction.ReadValue<Vector2>();
        player.Move(move);

        // Временный код для удобной проверки
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            m_states.GoToInventory();
        }

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            m_states.GoToQuests();
        }

        if (Keyboard.current.qKey.wasPressedThisFrame && WateringState.isActive)
        {
            m_states.Back();
        }
        else if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            m_states.GoToWatering();
        }
    }

    public void PointerDown()
    {
        m_rhythmCheck.InputDown();
    }

    public void PointerUp()
    {
        m_rhythmCheck.InputUp();
    }
}
