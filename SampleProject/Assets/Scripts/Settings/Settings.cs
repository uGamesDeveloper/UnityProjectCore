using UnityEngine;

public class Settings : MonoBehaviour
{
    #region var for incpector
    [SerializeField] private new Camera mainCamera;
    [SerializeField] public Camera CurrentCam;
    [SerializeField] public float distanceRaycast = 100;



    [Header("Layers")] 
    [SerializeField] private string layerMaskDragObj = "DragObj";
    
    [Header("Tags")] 
    [SerializeField] private string DragObj = "DragObj";

    #endregion
    
    public static Settings Instance;

    private void Awake()
    {
        Instance = this;

        Layer.layerMaskDragObj = LayerMask.NameToLayer(layerMaskDragObj);
        
        Tag.DragObj = DragObj;

        CurrentCam = mainCamera;
    }

    public class Layer
    {
        public static LayerMask layerMaskDragObj { get; set; }
    }
    
    public class Tag
    {
        public static string DragObj { get; set;  }
    }
}
