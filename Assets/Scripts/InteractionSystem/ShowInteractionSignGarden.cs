using System;
using TMPro;
using UnityEngine;

public class ShowInteractionSignGarden : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_interactionText;
    private InteractableGarden m_interactable;

    private void Awake()
    {
        m_interactable = gameObject.GetComponent<InteractableGarden>();

        m_interactable.onShow += OnShowSign;
        m_interactable.onUnShow += OnUnShowSign;
    }

    private void OnShowSign()
    {
        if (!m_interactable.soilHole.isBusy)
        {
            m_interactionText.text = "Press E to plant a seed";
        }
        else if (m_interactable.plant.isReadyToHarvest)
        {
            m_interactionText.text = "Press E to harvest a plant";
        }
        else if (!m_interactable.plant.isWatered && GameManager.instance.player.wateringPot.currentValue > 0 && WateringState.isActive)
        {
            m_interactionText.text = "Press E to water a plant";
        }
    }

    private void OnUnShowSign()
    {
        m_interactionText.text = "";
    }
}
