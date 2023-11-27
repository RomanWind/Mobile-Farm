using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SeedsPlant : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private Plot _plot;
	[SerializeField] private Plant _plant;
	[SerializeField] private PlayerStats _playerStats;

	[Header("Scriptable")]
	[SerializeField] private SeedsScriptableObject _seedScriptable;

	[Header("UI")]
	[SerializeField] private Image _seedsIcon;
	[SerializeField] private TextMeshProUGUI _seedsPrice;

	private void Start()
	{
		_seedsIcon.sprite = _seedScriptable.seedImage;
		_seedsPrice.text = _seedScriptable.seedPrice.ToString();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log(gameObject.name);

		if(_playerStats.GetCoinsAmount() >= _seedScriptable.seedPrice)
		{
			_playerStats.SetCoinsAmount(_playerStats.GetCoinsAmount() - _seedScriptable.seedPrice);
			_plant.SelectPlant(_seedScriptable.plant);
			_plot.StateChange(Plot.State.Growing);
			_plot.UnselectPlot();
		}
		else
		{
			Debug.Log("Not enought money");
		}
	}
}
