using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlantingState : GameStateBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXOpeningBag);
    }

    private void OnDisable()
    {
        GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXOpeningBag);
    }
}
