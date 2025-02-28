using System.Collections;
using DG.Tweening;
using UnityEngine;

public class UIMoving
{
    public IEnumerator Move(float fadeTime, RectTransform rectTransform, Ease ease, Vector2 anchor, Vector3 localPosition)
    {
        rectTransform.transform.localPosition = localPosition;
        Tween tween = rectTransform.DOAnchorPos(anchor, fadeTime, false).SetEase(ease).SetUpdate(true);
        yield return tween.WaitForCompletion();
    }
}
