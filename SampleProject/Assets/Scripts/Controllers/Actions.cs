using UnityEngine;
using UnityEngine.Events;

public class Actions : MonoBehaviour
{
	#region Settings
	[Header("Пользователь вытянул первую деталь")]
	[SerializeField] UnityEvent onDrag1DetailComplete;
	
	[Header("Камера изменилась")]
	[SerializeField] UnityEvent onCameraChanged;
	#endregion
	
	#region Variables

	/// Для вызова события используйте Actions.OnDrag1DetailComplete?.Invoke();
	public static UnityAction OnDrag1DetailComplete;
	public static UnityAction OnCameraChanged;

	#endregion
	
	#region UnityMethods
	private void Awake()
	{
		OnCameraChanged += CameraChangedHandler;
		OnDrag1DetailComplete += Drag1DetailCompleteHandler;
	}
	private void OnDestroy()
	{
		OnDrag1DetailComplete -= Drag1DetailCompleteHandler;
		OnCameraChanged -= CameraChangedHandler;
	}
	#endregion
	
	#region ActionsMethods
	private void CameraChangedHandler()
	{
		onCameraChanged?.Invoke();
	}
	private void Drag1DetailCompleteHandler()
	{
		onDrag1DetailComplete?.Invoke();
	}
	#endregion
}
