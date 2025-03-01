using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShowInteractionSign : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_interactionText;
    [SerializeField] private GameObject m_eImage;
    private Interactable m_interactable;
    private GameStateBehaviour m_state;
    private void Start()
    {
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
                m_interactionText.text = "To brew a potion - ";
                break;
            case ShoppingState:
                m_interactionText.text = "To open shop - ";
                break;
            case SleepState:
                m_interactionText.text = "To sleep and save - ";
                break;
            case TalkingState:
                m_interactionText.text = "To talk - ";
                break;
            case null:
                if (m_interactable.wateringPotController.gameObject.activeSelf && m_interactable.wateringPotController)
                {
                    m_interactionText.text = "To fill the pot - ";
                }
                break;
            default:
                m_interactionText.text = "";
                break;
        }

        if (m_interactionText.text != "")
        {
            m_eImage.SetActive(true);
        }
    }

    private void Hide()
    {
        m_eImage.SetActive(false);
        m_interactionText.text = "";
    }
}
