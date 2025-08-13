using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRLaserPointer : MonoBehaviour
{
    [Header("Laser Settings")]
    public float laserLength = 10f;
    public float laserWidth = 0.01f;
    public Color laserColor = Color.cyan;
    public Color hoverColor = Color.green;
    
    [Header("References")]
    public LineRenderer lineRenderer;
    public GameObject hitIndicator;
    
    private bool isHovering = false;
    private GameObject currentHoverObject;
    
    void Start()
    {
        SetupLaser();
    }
    
    void SetupLaser()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
            if (lineRenderer == null)
                lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth * 0.5f;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = laserColor;
        lineRenderer.positionCount = 2;
    }
    
    void Update()
    {
        UpdateLaser();
        HandleInput();
    }
    
    void UpdateLaser()
    {
        RaycastHit hit;
        Vector3 endPoint;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserLength))
        {
            endPoint = hit.point;
            
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject != currentHoverObject)
            {
                if (currentHoverObject != null)
                    OnHoverExit();
                currentHoverObject = hitObject;
                OnHoverEnter();
            }
        }
        else
        {
            endPoint = transform.position + transform.forward * laserLength;
            
            if (currentHoverObject != null)
            {
                OnHoverExit();
                currentHoverObject = null;
            }
        }
        
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, endPoint);
        }
    }
    
    void OnHoverEnter()
    {
        isHovering = true;
        if (lineRenderer != null)
            lineRenderer.material.color = hoverColor;
            
        ExecuteEvents.Execute(currentHoverObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
    }
    
    void OnHoverExit()
    {
        isHovering = false;
        if (lineRenderer != null)
            lineRenderer.material.color = laserColor;
            
        ExecuteEvents.Execute(currentHoverObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
    }
    
    void HandleInput()
    {
        if (Input.GetButtonDown("Fire1") && isHovering && currentHoverObject != null)
        {
            ExecuteEvents.Execute(currentHoverObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            
            Button button = currentHoverObject.GetComponent<Button>();
            if (button != null)
                button.onClick.Invoke();
        }
    }
}