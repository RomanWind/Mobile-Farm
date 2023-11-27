using UnityEngine;

[CreateAssetMenu(fileName = "SeedsScriptableObject", menuName = "ScriptableObjects/SeedsScriptableObject")]
public class SeedsScriptableObject : ScriptableObject
{
	public string seedName;
	public int seedPrice;
	public Sprite seedImage;
	public Sprite grownPlantImage;
	public PlantScriptableObject plant;
}
