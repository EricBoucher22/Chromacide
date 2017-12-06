using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacterMovement : MonoBehaviour
{
	Stack oldPath;

	// Use this for initialization
	void Start ()
	{
		oldPath = new Stack ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnMouseEnter()
	{
		Character active = CharacterCreate.Characters [0];
		oldPath = AStarFunctions.AStar(MapCreate.PositionReference - MapCreate.PositionReference, active.Instance.transform.position, transform.parent.position - MapCreate.PositionReference, active.Color);
		foreach(Vector2 arrayPos in oldPath)
		{
			Map.MapGameObjects [(int) arrayPos.x, (int) arrayPos.y].transform.GetChild(0).GetComponent<BlockPropertyChanger> ().HighlightMaterial ();
		}
	}

	void OnMouseExit()
	{
		foreach(Vector2 arrayPos in oldPath)
		{
			Map.MapGameObjects [(int) arrayPos.x, (int) arrayPos.y].transform.GetChild(0).GetComponent<BlockPropertyChanger> ().BaseMaterial ();
		}
	}
}
