using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PoppingUI
{
    private UIMoving m_uiMoving = new UIMoving();

    public IEnumerator PoppingItems(RectTransform[] items)
    {
        foreach (RectTransform item in items)
        {
            ShrinkItem(item);
        }

        foreach (RectTransform item in items)
        {
            PopItem(item);
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void PopItem(RectTransform item)
    {
        item.transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }

    public void ShrinkItem(RectTransform item)
    {
        item.transform.localScale = Vector3.zero;
    }
}
