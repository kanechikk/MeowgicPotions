using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{
    private RectTransform bgTransform;
    private TextMeshProUGUI textMeshProUGUI;
    private RectTransform tooltipTransform;
    public Vector2 padding = new Vector2(10, 10);
    private GameObject m_background;
    [SerializeField] private RectTransform canvasTransformArea;

    void Awake()
    {
        bgTransform = gameObject.GetComponentsInChildren<RectTransform>()[1];
        textMeshProUGUI = gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0];
        tooltipTransform = gameObject.GetComponent<RectTransform>();
        m_background = gameObject.GetComponentsInChildren<Transform>()[1].gameObject;
        SetText("test \n \n \n \n");
        HideTooltip();
    }

    private void SetText(string text)
    {
        textMeshProUGUI.SetText(text);
        textMeshProUGUI.ForceMeshUpdate();
        bgTransform.sizeDelta = textMeshProUGUI.GetRenderedValues(false) + padding;
    }
    void Update()
    {
        Vector2 position = Input.mousePosition / canvasTransformArea.localScale.y;

        //thing that stops tooltip from going offscreen (штука чтобы тултип не уходил за экран)
        if (position.x + bgTransform.rect.width > canvasTransformArea.rect.width) //right
        {
            position.x = canvasTransformArea.rect.width - bgTransform.rect.width;
        }
        
        if (position.x < 0) //left
        {
            position.x = 0;
        }

        if (position.y + bgTransform.rect.height > canvasTransformArea.rect.height) //up
        {
            position.y = canvasTransformArea.rect.height - bgTransform.rect.height;
        }

        if (position.y < 0) //down
        {
            position.y = 0;
        }

        tooltipTransform.anchoredPosition = position;
    }

    public void ShowTooltip(string tooltipText)
    {
        m_background.SetActive(true);
        SetText(tooltipText);
    }
    public void HideTooltip()
    {
        m_background.SetActive(false);
    }
}
