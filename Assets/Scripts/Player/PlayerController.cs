using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaeyrConroller : MonoBehaviour
{
    public Player player;
    public InputActionAsset inputActions;
    private InputAction m_moveAction;

    public InventoryState inventoryState;
    private InputAction m_inventoryAction;

    private void Start()
    {
        var map = inputActions.FindActionMap("Player");
        map.Enable();

        m_moveAction = map.FindAction("Move");

        m_inventoryAction = map.FindAction("OpenCloseInventory");
        m_inventoryAction.performed += OpenCloseInventory;
    }

    private void Update()
    {
        Vector2 move = m_moveAction.ReadValue<Vector2>();
        player.Move(move);
    }

    private void OpenCloseInventory(InputAction.CallbackContext context)
    {
        // открытие и закрытие инвентаря на I
        inventoryState.gameObject.SetActive(!inventoryState.gameObject.activeSelf);
    }
}
