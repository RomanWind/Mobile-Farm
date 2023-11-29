using UnityEngine;

public class WaterDrop : MonoBehaviour
{
	[SerializeField] private Watering _watering;
	[SerializeField] private Plot _plot;

	public void OnDropDisappear()
	{
		if (_watering.GetActiveWaterDropIndex() < 4)
			_watering.IncrementWaterDrop();
		else
			_plot.StateChange(Plot.State.Dead);
	}
}
