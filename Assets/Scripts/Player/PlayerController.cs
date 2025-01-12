using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaeyrConroller : MonoBehaviour
{
    public Player player;
    public InputActionAsset inputActions;
    private InputAction m_moveAction;
    
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
            inventoryState.SetActive(true);
        }
    }
}
