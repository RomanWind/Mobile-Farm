using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour, IPointerClickHandler
{
	public enum State
	{
		Empty,
		Growing,
		NeedWater,
		Dead,
		Ready
	}

	[SerializeField] private GameObject _selectionImage;
	[SerializeField] private GameObject _seeds;
	[SerializeField] private GameObject _watering;
	[SerializeField] private GameObject _plantObject;
	[SerializeField] private Plant _plant;
	[SerializeField] private PlotsSelection _plotsSelection;

	private State _state;
	private float _growingTimer;
	private bool _growingPause = false;
	private bool _plantWasWatered = false;

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

				if (!_growingPause)
					_growingTimer += Time.deltaTime;

				if(!_plantWasWatered)
				{
					switch (Convert.ToInt32(_growingTimer))
					{
						case 5:
							_growingPause = true;
							_state = State.NeedWater;
							break;
					}
				}

				_plant.PlantGrowthProgress(_growingTimer);
			break;
			case State.NeedWater:
				_watering.SetActive(true);
			break;
			case State.Dead:
				_watering.SetActive(false);
				_plant.PlantDryingOut();
				break;
			case State.Ready:

				break;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if(_state != State.NeedWater && _state != State.Dead)
			SelectPlot();

		ShowSeedsMenu();
		WaterThePlant();
		RemoveDeadPlant();
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

	private void WaterThePlant()
	{
		if(_state == State.NeedWater)
		{
			_watering.SetActive(false);
			_growingPause = false;
			_plantWasWatered = true;
			_state = State.Growing;
		}
	}

	private void RemoveDeadPlant()
	{
		if (_state == State.Dead)
		{
			_plantObject.SetActive(false);
			_growingTimer = 0f;
			_growingPause = false;
			_state = State.Empty;
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
