using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaeyrConroller : MonoBehaviour
{
    public Player player;
    public InputActionAsset inputActions;
    private InputAction m_moveAction;
    [SerializeField] private GameMode m_states;
    [SerializeField] private RhythmCheck m_rhythmCheck;
    private AudioManager m_audioManager;

    private void Start()
    {
        var map = inputActions.FindActionMap("Player");
        map.Enable();

        m_moveAction = map.FindAction("Move");

        m_audioManager = GameManager.instance.audioManager;
    }

    private void Update()
    {
        Vector2 move = m_moveAction.ReadValue<Vector2>();
        player.Move(move);

        if (Keyboard.current.iKey.wasPressedThisFrame && m_states.CurrGameState is not InventoryState)
        {
            m_states.GoToInventory();

            m_audioManager.PlaySFX(m_audioManager.SFXOpeningBag);
        }

        if (Keyboard.current.fKey.wasPressedThisFrame && m_states.CurrGameState is not CheckingQuestsState)
        {
            m_states.GoToQuests();

            m_audioManager.PlaySFX(m_audioManager.SFXOpeningBook);
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (m_states.CurrGameState is WalkingState)
            {
                m_states.GoToPause();

                m_audioManager.PlaySFX(m_audioManager.SFXSlidingIn);
            }
            else if (m_states.CurrGameState is not RhythmGameState)
            {
                m_states.Back();

                m_audioManager.PlaySFX(m_audioManager.SFXSlidingIn);
            }
        }

        if (Keyboard.current.qKey.wasPressedThisFrame && WateringState.isActive)
        {
            m_states.BackWhile();
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
