using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class BlockCharacterMovement : MonoBehaviour {

	private GameObject _gameManager;
	// Use this for initialization
	void Start ()
	{
		_gameManager = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnMouseEnter ()
	{
		if (enabled)
		{
			ExecuteEvents.Execute<IBlockMouseHandler> (_gameManager, null, (x, y) => x.HighlightPath (transform.position));
		}
	}

	void OnMouseExit ()
	{
		if (enabled)
		{
			ExecuteEvents.Execute<IBlockMouseHandler> (_gameManager, null, (x, y) => x.StopHighlightPath ());
		}
	}

	void OnMouseDown ()
	{
		if (enabled)
		{
			ExecuteEvents.Execute<IBlockMouseHandler> (_gameManager, null, (x, y) => x.MoveTo (transform.position));
		}
	}
}
