using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class BlockCharacterMovement : MonoBehaviour {

	private GameObject _gameManager;
	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter () {
		ExecuteEvents.Execute<IBlockMouseHandler> (_gameManager, null, (x, y) => x.HighlightPath (transform.position));
	}

	void OnMouseExit () {
		ExecuteEvents.Execute<IBlockMouseHandler> (_gameManager, null, (x, y) => x.StopHighlightPath ());
	}

	void OnMouseDown () {
		ExecuteEvents.Execute<IBlockMouseHandler> (_gameManager, null, (x, y) => x.MoveTo (transform.position));
	}
}
