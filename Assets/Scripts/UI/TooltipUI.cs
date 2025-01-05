using TMPro;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{
    //static instance cuz theres only 1 at a time (статичск штука т к только 1 существует одновременно)
    public static TooltipUI instance;
    [SerializeField] private RectTransform bgTransform;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private RectTransform canvasTransform;
    private RectTransform tooltipTransform;
    public Vector2 padding = new Vector2(10, 10);

    void Awake()
    {
        tooltipTransform = GetComponent<RectTransform>();
        instance = this;
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
        Vector2 position = Input.mousePosition / canvasTransform.localScale.y;

        //thing that stops tooltip from going offscreen (штука чтобы тултип не уходил за экран)
        if (position.x + bgTransform.rect.width > canvasTransform.rect.width) //right
        {
            position.x = canvasTransform.rect.width - bgTransform.rect.width;
        }
        if (position.x < 0) //left
        {
            position.x = 0;
        }

        if (position.y + bgTransform.rect.height > canvasTransform.rect.height) //up
        {
            position.y = canvasTransform.rect.height - bgTransform.rect.height;
        }
        if (position.y < 0) //down
        {
            position.y = 0;
        }

        tooltipTransform.anchoredPosition = position;
        //extra thoughts: here I tried to flip tooltip to be on bottom right from curson cuz its better lookin
        //do not do that
        //it WILL NOT work
        //fuck anchor points fuck reversed coordinate bullshit it does
    }

    private void ShowTooltipLocal(string tooltipText)
    {
        gameObject.SetActive(true);
        SetText(tooltipText);
    }
    private void HideTooltipLocal()
    {
        gameObject.SetActive(false);
        SetText("");
    }

    public static void ShowTooltip(string tooltipText)
    {
        instance.ShowTooltipLocal(tooltipText);
    }
    public static void HideTooltip()
    {
        instance.HideTooltipLocal();
    }
}
