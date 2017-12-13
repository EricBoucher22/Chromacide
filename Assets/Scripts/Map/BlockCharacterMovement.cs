using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlockCharacterMovement : MonoBehaviour
{
	Stack path;
	List<Vector3> pathPositions;

	// Use this for initialization
	void Start ()
	{
		path = new Stack ();
		pathPositions = new List<Vector3> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnMouseEnter()
	{
		Character active = CharacterCreate.Characters [0];
		path = AStarFunctions.AStar(MapCreate.PositionReference - MapCreate.PositionReference, active.Instance.transform.position, transform.parent.position - MapCreate.PositionReference, active.AffinityColor, active.MaxSquares);

		foreach(Vector2 arrayPos in path)
		{
			Map.MapGameObjects [(int) arrayPos.x, (int) arrayPos.y].transform.GetChild(0).GetComponent<BlockPropertyChanger> ().HighlightMaterial ();
		}
	}

	void OnMouseExit()
	{
		foreach(Vector2 arrayPos in path)
		{
			Map.MapGameObjects [(int) arrayPos.x, (int) arrayPos.y].transform.GetChild(0).GetComponent<BlockPropertyChanger> ().BaseMaterial ();
		}
	}

	void OnMouseDown()
	{
		pathPositions.Clear ();
		// make the the position list
		foreach(Vector2 arrayPosition in path)
		{
			pathPositions.Add (new Vector3(arrayPosition.y, 0, -arrayPosition.x) + MapCreate.PositionReference);
		}
		// call the function of movement



		//Character active = CharacterCreate.Characters [0];
		//active.Instance.GetComponent<NavMeshAgent> ().destination = pathPositions [0];

		//Debug.Log ("pathPositions=" + pathPositions[pathPositions.Count - 1]);
		//CharacterCreate.Characters [0].Instance.transform.position = pathPositions [pathPositions.Count - 1];
	}
}
