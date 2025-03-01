using System.Collections;
using DG.Tweening;
using UnityEngine;

public class UIRotation
{
    public IEnumerator Rotate(RectTransform rectTransform, Vector3 rotation, RotateMode rotateMode, float duration, Ease ease)
    {
        Tween tween = rectTransform.DORotate(rotation, duration, rotateMode).SetEase(ease).SetUpdate(true);
        yield return tween.WaitForCompletion();
    }
}
