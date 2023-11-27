using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour, IPointerClickHandler
{
	public enum State
	{
		Empty,
		Growing,
		NeedWater,
		Ready
	}

	[SerializeField] private GameObject _selectionImage;
	[SerializeField] private GameObject _seeds;
	[SerializeField] private GameObject _plantObject;
	[SerializeField] private Plant _plant;
	[SerializeField] private PlotsSelection _plotsSelection;

	private State _state;
	private float _growingTimer;

	private void Start()
	{
		_state = State.Empty;
		_plant = _plantObject.GetComponent<Plant>();
	}

	private void Update()
	{
		switch(_state)
		{
			case State.Empty:
				break; 
			case State.Growing:
				_plantObject.SetActive(true);
				_growingTimer += Time.deltaTime;
				_plant.PlantGrowthProgress(_growingTimer);
			break;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		SelectPlot();
		ShowSeedsMenu();
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

	private void ShowSeedsMenu()
	{
		if (_state == State.Empty)
		{
			_seeds.SetActive(true);
		}
	}

	public void UnselectPlot()
	{
		_seeds.SetActive(false);
		_selectionImage.SetActive(false);
		_plotsSelection.ResetSelectedPlot();
	}

	public void StateChange(State state) => _state = state;
}
