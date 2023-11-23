using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private GameObject _selectionImage;
	[SerializeField] private PlotsSelection _plotsSelection;

	private State _state;
	private float growingTimer;

	public enum State
	{
		Empty,
		Growing,
		NeedWater,
		Ready
	}

	private void Start()
	{
		_state = State.Empty;
	}

	private void Update()
	{
		switch(_state)
		{
			case State.Empty:
				break; 
			case State.Growing:
				growingTimer += Time.deltaTime;
			break;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		SelectPlot();
	}

	private void SelectPlot()
	{
		if (_plotsSelection.GetSelectedPlot() == null)
		{
			_selectionImage.SetActive(true);
			_plotsSelection.SetSelectedPlot(gameObject);
		}
		else if (_plotsSelection.GetSelectedPlot() != gameObject)
		{
			_plotsSelection.GetSelectedPlot().GetComponent<Plot>().UnselectPlot();
			_plotsSelection.ResetSelectedPlot();

			_selectionImage.SetActive(true);
			_plotsSelection.SetSelectedPlot(gameObject);
		}
		else
		{
			_plotsSelection.GetSelectedPlot().GetComponent<Plot>().UnselectPlot();
			_plotsSelection.ResetSelectedPlot();
		}
	}

	public void UnselectPlot()
	{
		_selectionImage.SetActive(false);
		_state = State.Empty;
	}
}
