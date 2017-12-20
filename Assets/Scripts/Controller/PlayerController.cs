using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IBlockMouseHandler
{
	[SerializeField] private PartyController _partyController;
	[SerializeField] private MoveController _moveController;

	private CharacterComponent _controlledCharacter;
	private Stack _path;
	private NavMeshAgent _currentAgent;
	private int counter;

	[HideInInspector] public bool _inputFrozen;

	// Use this for initialization
	void Start ()
	{
		_inputFrozen = false;
		_path = new Stack ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_currentAgent == null && _controlledCharacter != null)
		{
			_currentAgent = _controlledCharacter.gameObject.GetComponent<NavMeshAgent> ();
		}

		if (!_inputFrozen)
		{
			if (Input.GetKeyDown (KeyCode.Backspace))
			{
				_partyController.Next ();
				_currentAgent = _controlledCharacter.gameObject.GetComponent<NavMeshAgent> ();
			}
		}
	}

	void FixedUpdate()
	{
		// while perfoming action, the input is frozen.
		if (_inputFrozen && 
			!_moveController.IsInMovementQueue (_currentAgent) &&
			_currentAgent.pathStatus==NavMeshPathStatus.PathComplete && 
			_currentAgent.remainingDistance == 0)
		{
			counter++;
			if (counter == 3)
			{
				_inputFrozen = false;
				StopHighlightPath ();
				_path.Clear ();
				counter = 0;

				_controlledCharacter.CharacterAnimation (false);
			}
		}
	}

	public void PlayCharacter (CharacterComponent character)
	{
		if (_controlledCharacter != null)
		{
			_controlledCharacter.GetComponent<NavMeshAgent> ().enabled = false;
			_controlledCharacter.PlayedSquares = 0;
		}
		_controlledCharacter = character;
		Map.ActivateColor (_controlledCharacter.AffinityColor);
	}

	public void HighlightPath (Vector3 block_position)
	{
		if (!_inputFrozen)
		{
			if (_moveController._movementType == MovementType.Grid)
			{
				_path = AStarFunctions.AStar (
					MapCreate.PositionReference, 
					_controlledCharacter.transform.position, 
					block_position, 
					_controlledCharacter.AffinityColor, 
					_controlledCharacter.MaxSquares - _controlledCharacter.PlayedSquares,
					_partyController.GetCharactersQueue ());
			}
			else if (_moveController._movementType == MovementType.Free)
			{
				_path = new Stack ();
				bool occupied = false;
				foreach (CharacterComponent comp in _partyController.GetCharactersQueue ())
				{
					Vector3 vect_comp = comp.transform.position;
					if (Vector3.Distance(vect_comp, block_position) < 0.1f)
					{
						occupied = true;
						break;
					}
				}
				if (!occupied)
				{
					Vector3 vec_block_pos = block_position - MapCreate.PositionReference;
					_path.Push (new Vector2 (-vec_block_pos.z, vec_block_pos.x));
				}
			}

			foreach (Vector2 arrayPos in _path)
			{
				Map.MapGameObjects [(int)arrayPos.x, (int)arrayPos.y].transform.GetChild (0).GetComponent<BlockPropertyChanger> ().HighlightMaterial ();
			}
		}
	}

	public void StopHighlightPath ()
	{
		if (!_inputFrozen)
		{
			foreach (Vector2 arrayPos in _path)
			{
				Map.MapGameObjects [(int)arrayPos.x, (int)arrayPos.y].transform.GetChild (0).GetComponent<BlockPropertyChanger> ().BaseMaterial ();
			}
		}
	}

	public void MoveTo (Vector3 block_position)
	{
		if (!_inputFrozen)
		{
			List<Vector3> pathPositions = new List<Vector3> ();
			if (_path.Count != 0)
			{
				// make the the position list
				foreach (Vector2 arrayPosition in _path)
				{
					pathPositions.Add (new Vector3 (arrayPosition.y, 0, -arrayPosition.x) + MapCreate.PositionReference);
				}

				_controlledCharacter.PlayedSquares += _path.Count;

				// call the function of movement
				Debug.Log (_controlledCharacter.Name + " " + (_controlledCharacter.GetComponent<NavMeshAgent> () == null));

				_controlledCharacter.CharacterAnimation (true);

				NavMeshAgent agent = _controlledCharacter.GetComponent<NavMeshAgent> ();
				agent.enabled = true;

				_moveController.MoveTo (
					agent, 
					pathPositions);
				_inputFrozen = true;
			}
		}
	}
}
