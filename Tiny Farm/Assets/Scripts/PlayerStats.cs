using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	[SerializeField] private int _coins;

	public int GetCoinsAmount() => _coins;
	public int SetCoinsAmount(int coins) => _coins = coins;
}
