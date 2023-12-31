using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
	[SerializeField] private Plot _plot;

	private SpriteRenderer _currentPlantSprite;
	private PlantScriptableObject _currentPlant;

	private void Awake()
	{
		_currentPlantSprite = GetComponent<SpriteRenderer>();
	}

	private void OnEnable()
	{
		_currentPlantSprite.sprite = _currentPlant.growthStages[0];
	}

	public void SelectPlant(PlantScriptableObject plantScriptableObject) => _currentPlant = plantScriptableObject;

	public void PlantGrowthProgress(float growthTime)
	{
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

	public void PlantDryingOut()
	{
		_currentPlantSprite.sprite = _currentPlant.dryPlant;
	}
}
