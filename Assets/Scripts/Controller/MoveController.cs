using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

	private Dictionary<GameObject, List<Vector3>> _moveToQueue;

	// Use this for initialization
	void Start () {
		_moveToQueue = new Dictionary<GameObject, List<Vector3>> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (KeyValuePair<GameObject, List<Vector3>> moveTo in _moveToQueue) {
			
		}
	}

	public void MoveTo (GameObject toMove, List<Vector3> positions) {
		if (_moveToQueue.ContainsKey (toMove)) {
			_moveToQueue [toMove].AddRange (positions);
		} else {
			_moveToQueue.Add (toMove, positions);
		}
	}
}
