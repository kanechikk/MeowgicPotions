using System;
using TMPro;
using UnityEngine;

public class ShowInteractionSignGarden : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_interactionText;
    [SerializeField] private GameObject m_eImage;
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
            m_eImage.SetActive(true);
            m_interactionText.text = "To plant a seed - ";
        }
        else if (m_interactable.plant.isReadyToHarvest)
        {
            m_eImage.SetActive(true);
            m_interactionText.text = "To harvest a plant - ";
        }
        else if (!m_interactable.plant.isWatered && GameManager.instance.player.wateringPot.currentValue > 0 && WateringState.isActive)
        {
            m_eImage.SetActive(true);
            m_interactionText.text = "To water a plant - ";
        }

        if (m_interactionText.text != "")
        {
            m_eImage.SetActive(true);
        }

    }

    private void OnUnShowSign()
    {
        m_eImage.SetActive(false);
        m_interactionText.text = "";
    }
}
