using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShowInteractionSign : MonoBehaviour
{
    [SerializeField] private GameObject m_interactionInfo;
    private TextMeshProUGUI m_interactionText;
    private Interactable m_interactable;
    private GameStateBehaviour m_state;
    private void Start()
    {
        m_interactionText = m_interactionInfo.GetComponentInChildren<TextMeshProUGUI>();
        m_interactable = gameObject.GetComponent<Interactable>();
        m_state = m_interactable.stateOfInteractable;
        m_interactable.onActive += Show;
        m_interactable.onDeactive += Hide;
    }

    private void Show()
    {
        switch (m_state)
        {
            case BrewingState:
                m_interactionText.text = "Press E to brew a potion";
                break;
            case ShoppingState:
                m_interactionText.text = "Press E to open shop";
                break;
            case SleepState:
                m_interactionText.text = "Press E to sleep and save";
                break;
            case TalkingState:
                m_interactionText.text = "Press E to talk";
                break;
            case null:
                if (m_interactable.wateringPotController.gameObject.activeSelf && m_interactable.wateringPotController)
                {
                    m_interactionText.text = "Press E to fill the pot";
                }
                break;
            default:
                m_interactionText.text = "Press E";
                break;
        }
    }

    private void Hide()
    {
        m_interactionText.text = "";
    }
}
