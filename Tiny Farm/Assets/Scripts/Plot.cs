using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log(gameObject.name);
	}
}
