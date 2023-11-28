using UnityEngine;

public class WaterDrop : MonoBehaviour
{
	[SerializeField] private Watering _watering;
	public void OnDropDisappear()
	{
        if (_watering.GetActiveWaterDropIndex() < 4)
			_watering.IncrementWaterDrop();
	}
}
