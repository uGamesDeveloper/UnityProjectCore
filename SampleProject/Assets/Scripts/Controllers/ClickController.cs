using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    public static ClickController ClickControl = null;
    
    [SerializeField]
    Camera cam;
    Ray ray;
    RaycastHit _hit;
    
    [SerializeField]
    LayerMask layerMask;
    
    GameObject temp;
    
    void Awake()
    {
        if(ClickControl == null) ClickControl = this; 
    }
    
    enum Events
    {
        click,
        drag,
        upclick,
        stateSelection
    }
    
    [SerializeField]
    Events currentEvent;

    public void ChangeCamera()
    {
        cam = Settings.Instance.CurrentCam;
    }
    
    void Start()
    {
        currentEvent = Events.stateSelection;
    }

    // Update is called once per frame
    void Update()
    {
        #region System State
        if(currentEvent == Events.stateSelection)
        {
            stateSelection();
        }
        else if(currentEvent == Events.click)
        {
            MouseClick();
        }
        else if(currentEvent == Events.drag)
        {
            MouseDrag();
        }
        else if(currentEvent == Events.upclick)
        {
            MouseUp();
        }
        #endregion
    }
    
    #region Fucntions

    void stateSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentEvent = Events.click;
        }
    }
    void MouseClick()
    {
        ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        _hit = new RaycastHit();
        layerMask = Settings.Layer.layerMaskDragObj;
        Physics.Raycast(ray, out _hit, Settings.Instance.distanceRaycast);
        if (_hit.collider)
        {
            temp = _hit.transform.gameObject;
            if (_hit.collider.gameObject.CompareTag(Settings.Tag.DragObj))
            {
                Debug.LogError(Settings.Tag.DragObj);
                _hit.collider.GetComponent<DragObj>().currentEvent = DragObj.Events.click;
                currentEvent = Events.drag;
            }
        }
    }
    
    void MouseDrag()
    {
        if (Input.GetMouseButtonUp(0))
        {
            currentEvent = Events.upclick;
        }
    }
    
    void MouseUp()
    {
        if(temp && temp.CompareTag(Settings.Tag.DragObj))
            temp.GetComponent<DragObj>().currentEvent = DragObj.Events.upclick;

        
        currentEvent = Events.stateSelection;
    }
    #endregion
}
