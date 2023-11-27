using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlotsSelection : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private GameObject _selectedPlot;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (_selectedPlot != null)
		{
			Plot plot = _selectedPlot.GetComponent<Plot>();
			plot.UnselectPlot();
			_selectedPlot = null;
		}
	}

	public GameObject GetSelectedPlot() => _selectedPlot;
	public void SetSelectedPlot(GameObject plot) => _selectedPlot = plot;
	public void ResetSelectedPlot() => _selectedPlot = null;
}
