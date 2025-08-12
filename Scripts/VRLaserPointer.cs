using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// VR Laser Pointer for Meta Quest 3
/// Provides visual laser feedback for VR interactions
/// Attached to Right Controller
/// </summary>
public class VRLaserPointer : MonoBehaviour
{
    [Header("Laser Settings")]
    [Tooltip("Maximum length of the laser beam")]
    public float laserMaxLength = 10f;
    
    [Tooltip("Width of the laser beam")]
    public float laserWidth = 0.01f;
    
    [Tooltip("Default color of the laser")]
    public Color laserColor = Color.cyan;
    
    [Tooltip("Color when hitting an object")]
    public Color hitColor = Color.green;
    
    [Header("Components")]
    public LineRenderer lineRenderer;
    
    // Private variables
    private RaycastHit hitInfo;
    private bool isHitting = false;
    
    void Start()
    {
        // Auto-add LineRenderer if not assigned
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
            if (lineRenderer == null)
            {
                lineRenderer = gameObject.AddComponent<LineRenderer>();
            }
        }
        
        ConfigureLineRenderer();
        Debug.Log("[VRLaserPointer] Initialized on " + gameObject.name);
    }
    
    void ConfigureLineRenderer()
    {
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth * 0.5f; // Taper for better visual
        
        // Create simple material if needed
        if (lineRenderer.material == null)
        {
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        }
        
        lineRenderer.startColor = laserColor;
        lineRenderer.endColor = laserColor;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
    }
    
    void Update()
    {
        UpdateLaser();
    }
    
    void UpdateLaser()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + transform.forward * laserMaxLength;
        
        // Perform raycast to detect objects
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, laserMaxLength))
        {
            isHitting = true;
            endPos = hitInfo.point;
            
            // Change color when hitting an object
            lineRenderer.startColor = hitColor;
            lineRenderer.endColor = hitColor;
            
            // Optional: Add hit effect or feedback here
        }
        else
        {
            isHitting = false;
            lineRenderer.startColor = laserColor;
            lineRenderer.endColor = laserColor;
        }
        
        // Update line positions
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
    
    /// <summary>
    /// Check if the laser is currently hitting something
    /// </summary>
    public bool IsHitting()
    {
        return isHitting;
    }
    
    /// <summary>
    /// Get information about what the laser is hitting
    /// </summary>
    public RaycastHit GetHitInfo()
    {
        return hitInfo;
    }
    
    /// <summary>
    /// Get the GameObject that the laser is hitting
    /// </summary>
    public GameObject GetHitObject()
    {
        return isHitting ? hitInfo.collider.gameObject : null;
    }
    
    /// <summary>
    /// Enable or disable the laser
    /// </summary>
    public void SetLaserEnabled(bool enabled)
    {
        lineRenderer.enabled = enabled;
    }
}