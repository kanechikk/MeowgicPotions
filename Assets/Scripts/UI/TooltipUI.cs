
using TMPro;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{

    [SerializeField] private RectTransform bgTransform;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private RectTransform canvasTransform;
    private RectTransform tooltipTransform; //rename
    public Vector2 padding = new Vector2(10, 10);

    void Awake()
    {
        tooltipTransform = GetComponent<RectTransform>();
        SetText("test");
    }

    private void SetText(string text)
    {
        textMeshProUGUI.SetText(text);
        textMeshProUGUI.ForceMeshUpdate();
        bgTransform.sizeDelta = textMeshProUGUI.GetRenderedValues(false) + padding;
    }
    void Update()
    {
        Vector2 position = Input.mousePosition / canvasTransform.localScale.y;

        if (position.x + bgTransform.rect.width > canvasTransform.rect.width)
        {
            position.x = canvasTransform.rect.width - bgTransform.rect.width;
        }
        if (position.y + bgTransform.rect.height > canvasTransform.rect.height)
        {
            position.y = canvasTransform.rect.height - bgTransform.rect.height;
        }

        tooltipTransform.anchoredPosition = position;
    }

}
