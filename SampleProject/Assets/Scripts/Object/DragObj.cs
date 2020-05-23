using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEditor;

public class DragObj : MonoBehaviour
{
    [Header("Введи чувствительность")]
    [SerializeField]
    private float sensitivity = 0.005f;

    [Header("Объект статичен?")]
    [SerializeField]
    private bool staticObj;
    private Vector3 staticPos;
    Vector3 startPos;
    
    [Header("Движения по осям: ")]
    [SerializeField]
    bool X;
    [SerializeField]
    bool Y;

    [Header("Ограничение для движения по осям: ")]
    [SerializeField]
    Vector3 min_XYZ;
    [SerializeField]
    Vector3 max_XYZ;
    
    //Mouse pos
    Vector3 nowMousePos;
    Vector3 lastMousePos;
    Vector3 deltaMousePos = new Vector3(0, 0, 0);
    
    public static DragObj Drag = null;
    
    
    [Header("Объект вращается?")]
    [SerializeField]
    public bool rotate;

    public enum Events
    {
        stay,
        drag,
        click,
        upclick
    }
    
    [SerializeField]
    public Events currentEvent;
    
    void Awake()
    {
        if(Drag == null) Drag = this;
    }
    
    void Start()
    {
        staticPos = transform.position;
    }
    
    public void OnDown()
    {
        nowMousePos = Input.mousePosition;
        startPos = transform.position;

        currentEvent = Events.drag;
    }

    public void OnDrag()
    {
        lastMousePos = nowMousePos;
        nowMousePos = Input.mousePosition;
        deltaMousePos = nowMousePos - lastMousePos;
        
        if(X && max_XYZ.x >= transform.position.x && min_XYZ.x <= transform.position.x)
            transform.Translate(new Vector3(1, 0, 0) * deltaMousePos.x * sensitivity);
        if(Y && max_XYZ.y >= transform.position.y && min_XYZ.y <= transform.position.y)
            transform.Translate(new Vector3(0, 1, 0) * deltaMousePos.y * sensitivity);

    }
    
    public void OnDragRotate()
    {
        lastMousePos = nowMousePos;
        nowMousePos = Input.mousePosition;
        deltaMousePos = nowMousePos - lastMousePos;
        
        if(X && max_XYZ.x >= transform.position.x && min_XYZ.x <= transform.position.x)
            transform.Rotate(new Vector3(0, 0, -1) * deltaMousePos.y * sensitivity);
        if(Y && max_XYZ.y >= transform.position.y && min_XYZ.y <= transform.position.y)
            transform.Rotate(new Vector3(0, 1, 0) * deltaMousePos.x * sensitivity);
    }

    public void OnUp()
    {
        deltaMousePos = Vector3.zero;

        currentEvent = Events.stay;
    }

    public void OnStay()
    {
        if (staticObj)
        {
            transform.position = Vector3.Lerp(transform.position, staticPos, 1f);
        }
    }

        void Update()
    {
        #region System State

        if (currentEvent == Events.stay)
        {
            OnStay();
        }
        else if(currentEvent == Events.click)
        {
            OnDown();
        }
        else if(currentEvent == Events.drag)
        {
            if(rotate)
                OnDragRotate();
            else
            {
                OnDrag();
            }
                
        }
        else if(currentEvent == Events.upclick)
        {
            OnUp();
        }
        #endregion
    }
}
