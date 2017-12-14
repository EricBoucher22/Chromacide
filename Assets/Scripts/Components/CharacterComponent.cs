using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType {
	PLAYABLE,
	IA_CONTROLLED
}

[System.Serializable]
public class CharacterComponent : MonoBehaviour {
	[SerializeField] private string _name;
	[SerializeField] private CharacterType _type;
	[SerializeField] private int _actionPointsByTurn;
	[SerializeField] private int _actionPointsLeft;
	[SerializeField] private int _maxSquares;
	[SerializeField] private AffinityColor _affinityColor;

	public CharacterType GetType () {
		return _type;
	}

	public int MaxSquares {
		get {
			return _maxSquares;
		}
		set {
			_maxSquares = value;
		}
	}

	public string Name {
		get {
			return _name;
		}
		set {
			_name = value;
		}
	}

	public AffinityColor AffinityColor {
		get {
			return _affinityColor;
		}
		set {
			_affinityColor = value;
		}
	}
}
