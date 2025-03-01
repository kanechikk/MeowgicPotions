using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionBookState : GameStateBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXOpeningBook);
    }

    private void OnDisable()
    {
        GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXOpeningBook);
    }
}
