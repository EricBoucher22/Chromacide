using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveController : MonoBehaviour {
	[SerializeField] private float _nominalSpeed;
	private Dictionary<NavMeshAgent, List<Vector3>> _moveToQueue;

	// Use this for initialization
	void Start () {
		_moveToQueue = new Dictionary<NavMeshAgent, List<Vector3>> ();
	}

	void FixedUpdate () {
		List<NavMeshAgent> agents_to_remove = new List<NavMeshAgent> ();
		foreach (KeyValuePair<NavMeshAgent, List<Vector3>> moveTo in _moveToQueue) {
			NavMeshAgent agent = moveTo.Key;
			if (!agent.pathPending && !agent.hasPath) {
				agent.SetDestination (moveTo.Value [0]);
				moveTo.Value.RemoveAt (0);
				if (moveTo.Value.Count == 0) {
					agents_to_remove.Add (agent);
				}
			}
		}

		foreach (NavMeshAgent agent in agents_to_remove) {
			_moveToQueue.Remove (agent);
		}
	}

	public void MoveTo (NavMeshAgent toMove, List<Vector3> positions) {
		if (_moveToQueue.ContainsKey (toMove)) {
			_moveToQueue [toMove].AddRange (positions);
		} else {
			_moveToQueue.Add (toMove, positions);
		}
	}
}
