using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChannelItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("UI References")]
    public Image icon;
    public Text label;
    public Image backgroundImage;
    
    [Header("Colors")]
    public Color normalColor = new Color(0.2f, 0.2f, 0.2f, 0.8f);
    public Color hoverColor = new Color(0.3f, 0.3f, 0.3f, 0.9f);
    public Color selectedColor = new Color(0.4f, 0.4f, 0.1f, 1f);
    
    [Header("Data")]
    public string channelName;
    public Sprite channelIcon;
    
    private bool isSelected = false;
    private static ChannelItem currentlySelected;
    
    void Start()
    {
        if (backgroundImage == null)
            backgroundImage = GetComponent<Image>();
            
        if (backgroundImage != null)
            backgroundImage.color = normalColor;
            
        if (label != null && !string.IsNullOrEmpty(channelName))
            label.text = channelName;
            
        if (icon != null && channelIcon != null)
            icon.sprite = channelIcon;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected && backgroundImage != null)
        {
            backgroundImage.color = hoverColor;
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected && backgroundImage != null)
        {
            backgroundImage.color = normalColor;
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        SelectChannel();
    }
    
    public void SelectChannel()
    {
        // Deselect previous
        if (currentlySelected != null && currentlySelected != this)
        {
            currentlySelected.Deselect();
        }
        
        // Select this
        isSelected = true;
        currentlySelected = this;
        
        if (backgroundImage != null)
            backgroundImage.color = selectedColor;
            
        // Trigger channel change event
        VRUIManager manager = FindObjectOfType<VRUIManager>();
        if (manager != null)
        {
            manager.OnChannelSelected(channelName);
        }
    }
    
    public void Deselect()
    {
        isSelected = false;
        if (backgroundImage != null)
            backgroundImage.color = normalColor;
    }
}