using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRUIManager : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject channelsPanel;
    public GameObject contentPanel;
    public GameObject favoritesPanel;
    
    [Header("Channel System")]
    public Transform channelContentContainer;
    public GameObject channelItemPrefab;
    public ScrollRect channelScrollRect;
    
    [Header("Content Display")]
    public Transform contentGridContainer;
    public GameObject thumbnailPrefab;
    
    [Header("Animation Settings")]
    public float panelFadeSpeed = 2f;
    public float scrollSpeed = 5f;
    
    [System.Serializable]
    public class ChannelData
    {
        public string name;
        public Sprite icon;
        public string[] contentIds;
    }
    
    [System.Serializable]
    public class ContentData
    {
        public string id;
        public string title;
        public Sprite thumbnail;
        public string duration;
        public string filePath;
    }
    
    [Header("Data")]
    public List<ChannelData> channels = new List<ChannelData>();
    public List<ContentData> contents = new List<ContentData>();
    
    private string currentChannel = "";
    
    void Start()
    {
        InitializeUI();
        LoadChannels();
        SetupScrollRectForVR();
    }
    
    void InitializeUI()
    {
        // Set initial panel states
        if (channelsPanel != null)
            SetPanelAlpha(channelsPanel, 1f);
            
        if (contentPanel != null)
            SetPanelAlpha(contentPanel, 1f);
            
        if (favoritesPanel != null)
            SetPanelAlpha(favoritesPanel, 0.7f);
    }
    
    void SetPanelAlpha(GameObject panel, float alpha)
    {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = panel.AddComponent<CanvasGroup>();
            
        canvasGroup.alpha = alpha;
        canvasGroup.interactable = alpha > 0.5f;
        canvasGroup.blocksRaycasts = alpha > 0.5f;
    }
    
    void LoadChannels()
    {
        // Add default channels if empty
        if (channels.Count == 0)
        {
            channels.Add(new ChannelData { name = "Local Files" });
            channels.Add(new ChannelData { name = "VR Videos" });
            channels.Add(new ChannelData { name = "Network" });
            channels.Add(new ChannelData { name = "AirScreen" });
            channels.Add(new ChannelData { name = "YouTube" });
            channels.Add(new ChannelData { name = "Hidden Files" });
        }
        
        // Create channel items
        if (channelContentContainer != null && channelItemPrefab != null)
        {
            foreach (var channel in channels)
            {
                GameObject item = Instantiate(channelItemPrefab, channelContentContainer);
                ChannelItem channelItem = item.GetComponent<ChannelItem>();
                if (channelItem != null)
                {
                    channelItem.channelName = channel.name;
                    channelItem.channelIcon = channel.icon;
                }
            }
        }
    }
    
    void SetupScrollRectForVR()
    {
        if (channelScrollRect != null)
        {
            // Configure scroll rect for better VR interaction
            channelScrollRect.scrollSensitivity = 30f;
            channelScrollRect.elasticity = 0.1f;
            channelScrollRect.decelerationRate = 0.135f;
            
            // Link content to scroll rect
            if (channelContentContainer != null)
            {
                channelScrollRect.content = channelContentContainer.GetComponent<RectTransform>();
            }
        }
    }
    
    public void OnChannelSelected(string channelName)
    {
        currentChannel = channelName;
        Debug.Log($"Channel selected: {channelName}");
        
        // Load content for selected channel
        LoadContentForChannel(channelName);
        
        // Animate panel focus
        StartCoroutine(AnimatePanelFocus(contentPanel));
    }
    
    void LoadContentForChannel(string channelName)
    {
        // Clear existing content
        if (contentGridContainer != null)
        {
            foreach (Transform child in contentGridContainer)
            {
                Destroy(child.gameObject);
            }
        }
        
        // Load new content based on channel
        // This would load actual content in production
        Debug.Log($"Loading content for channel: {channelName}");
    }
    
    IEnumerator AnimatePanelFocus(GameObject panel)
    {
        if (panel == null) yield break;
        
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = panel.AddComponent<CanvasGroup>();
            
        float targetAlpha = 1f;
        float currentAlpha = canvasGroup.alpha;
        float elapsed = 0f;
        
        while (elapsed < 0.5f)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(currentAlpha, targetAlpha, elapsed * panelFadeSpeed);
            yield return null;
        }
        
        canvasGroup.alpha = targetAlpha;
    }
    
    public void OnThumbnailHover(GameObject thumbnail)
    {
        // Add hover effect
        if (thumbnail != null)
        {
            thumbnail.transform.localScale = Vector3.one * 1.05f;
        }
    }
    
    public void OnThumbnailExit(GameObject thumbnail)
    {
        // Remove hover effect
        if (thumbnail != null)
        {
            thumbnail.transform.localScale = Vector3.one;
        }
    }
}