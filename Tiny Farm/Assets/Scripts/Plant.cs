using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
	[SerializeField] private Plot _plot;

	private SpriteRenderer _currentPlantSprite;
	private PlantScriptableObject _currentPlant;

	private void Start()
	{
		_currentPlantSprite = gameObject.GetComponent<SpriteRenderer>();
		_currentPlantSprite.sprite = _currentPlant.growthStages[0];
	}

	public void SelectPlant(PlantScriptableObject plantScriptableObject) => _currentPlant = plantScriptableObject;

	public void PlantGrowthProgress(float growthTime)
	{
		Debug.Log($"PlantGrowthProgress and growthTime: {Convert.ToInt32(growthTime)}");

		switch (Convert.ToInt32(growthTime))
		{
			case 3:
				_currentPlantSprite.sprite = _currentPlant.growthStages[1];
				break;
			case 6:
				_currentPlantSprite.sprite = _currentPlant.growthStages[2];
				break;
			case 9:
				_currentPlantSprite.sprite = _currentPlant.growthStages[3];
				_plot.StateChange(Plot.State.Ready);
				break;
		}
	}
}
