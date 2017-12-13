using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IBlockMouseHandler {
	[SerializeField] private PartyController _partyController;
	[SerializeField] private MoveController _moveController;
	private CharacterComponent _controlledCharacter;
	private bool _inputFrozen;

	private Stack path;

	// Use this for initialization
	void Start () {
		_inputFrozen = false;
		path = new Stack ();
	}
	
	// Update is called once per frame
	void Update () {
		// while perfoming action, the input is frozen.

		if (Input.GetKeyDown (KeyCode.Backspace)) {
			_partyController.Next ();
		}
	}

	public void PlayCharacter (CharacterComponent character) {
		_controlledCharacter = character;
	}


	public void HighlightPath (Vector3 block_position) {
		path = AStarFunctions.AStar (
			MapCreate.PositionReference, 
			_controlledCharacter.transform.position - MapCreate.PositionReference, 
			block_position - MapCreate.PositionReference, 
			_controlledCharacter.AffinityColor, 
			_controlledCharacter.MaxSquares);

		foreach (Vector2 arrayPos in path) {
			Map.MapGameObjects [(int)arrayPos.x, (int)arrayPos.y].transform.GetChild (0).GetComponent<BlockPropertyChanger> ().HighlightMaterial ();
		}
	}

	public void StopHighlightPath () {
		foreach (Vector2 arrayPos in path) {
			Map.MapGameObjects [(int)arrayPos.x, (int)arrayPos.y].transform.GetChild (0).GetComponent<BlockPropertyChanger> ().BaseMaterial ();
		}
	}

	public void MoveTo (Vector3 block_position) {
		List<Vector3> pathPositions = new List<Vector3> ();
		// make the the position list
		foreach (Vector2 arrayPosition in path) {
			pathPositions.Add (new Vector3 (arrayPosition.y, 0, -arrayPosition.x) + MapCreate.PositionReference);
		}
		// call the function of movement
		Debug.Log (_controlledCharacter.Name + " " + (_controlledCharacter.GetComponent<NavMeshAgent> () == null));
		_moveController.MoveTo (
			_controlledCharacter.gameObject.GetComponent<NavMeshAgent> (), 
			pathPositions);
	}
}
