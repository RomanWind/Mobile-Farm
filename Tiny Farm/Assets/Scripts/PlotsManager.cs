using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlotsManager : MonoBehaviour
{
	[SerializeField] LayerMask _plotMask;
	[SerializeField] List<GameObject> _plots;

	private void Update()
	{
		//SelectPlot();
	}

	private void SelectPlot()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));

			Vector3 direction = transform.position - touchPosition;
			RaycastHit2D hit = Physics2D.Raycast(touchPosition, direction, 10, _plotMask);
			float _interactionLength = 0.75f;
			if (hit.collider != null && direction.x <= _interactionLength && direction.y <= _interactionLength)
			{
				Debug.Log(hit.collider.transform.name);
			}
		}
	}

	private Vector3 ClosestPlotSelection(List<GameObject> plots, Transform touchPosition)
	{
		Vector3 closestPlot = plots[0].transform.position;

		foreach (GameObject plot in plots)
		{

		}

		return closestPlot;
	}

}
