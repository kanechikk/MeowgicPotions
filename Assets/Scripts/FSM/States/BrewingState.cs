using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BrewingState : GameStateBehaviour
{
    private void OnEnable()
    {
		GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.SFXOpeningBrewing);
	}
}
