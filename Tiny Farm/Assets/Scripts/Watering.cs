using System;
using UnityEngine;
using UnityEngine.UI;

public class Watering : MonoBehaviour
{
	[SerializeField] private GameObject[] _waterDrops = new GameObject[5];

	private Image[] _waterDropsImages = new Image[5];
	private Animator _activeAnimator;
	private int _activeWaterDrop = 0;

	private void Awake()
	{
		for (int i = 0; i < _waterDrops.Length; i++)
		{
			_waterDropsImages[i] = _waterDrops[i].GetComponent<Image>();
		}
	}

	private void OnEnable()
	{
		_activeWaterDrop = 0;
		NextWaterDropActivation(_activeWaterDrop);
	}

	private void OnDisable()
	{
		_activeWaterDrop = 0;
		_activeAnimator = _waterDrops[_activeWaterDrop].GetComponent<Animator>();
	}

	private void NextWaterDropActivation(int index)
	{
		_activeAnimator = _waterDrops[index].GetComponent<Animator>();
		_activeAnimator.SetBool("Disappear", true);
	}

	public void IncrementWaterDrop()
	{
		_activeWaterDrop++;
		NextWaterDropActivation(_activeWaterDrop);
	}

	public int GetActiveWaterDropIndex() => _activeWaterDrop;
}
