using UnityEngine;

[CreateAssetMenu(fileName = "PlantScriptableObject", menuName = "ScriptableObjects/PlantScriptableObject")]
public class PlantScriptableObject : ScriptableObject
{
	public Sprite[] growthStages = new Sprite[4];
	public Sprite dryPlant;
}
