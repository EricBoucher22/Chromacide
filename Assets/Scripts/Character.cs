using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
	#region private variables
	public string _name;
	public AffinityColor _color;
	public Vector2 _initialPosition;
	public GameObject _model;
	[HideInInspector] public GameObject _instance;
	#endregion

	#region constructors
	public Character (string name, AffinityColor color, Vector3 initialPosition, GameObject model, GameObject instance)
	{
		_color = color;
		_name = name;
		_initialPosition = initialPosition;
		_instance = instance;
	}
	#endregion

	#region getters and setters (properties)
	public string Name
	{
		get
		{
			return _name;
		}

		set
		{
			_name = value;
		}
	}

	public AffinityColor Color
	{
		get
		{
			return _color;
		}

		set
		{
			_color = value;
		}
	}

	public Vector3 InitialPosition
	{
		get
		{
			return _initialPosition;
		}
		set
		{
			_initialPosition = value;
		}
	}

	public GameObject Model
	{
		get
		{
			return _model;
		}
		set
		{
			_model = value;
		}
	}

	public GameObject Instance
	{
		get
		{
			return _instance;
		}
		set
		{
			_instance = value;
		}
	}
	#endregion

	#region public functions
	public void CreateCharacter(Transform parent)
	{
		Instance = GameObject.Instantiate (Model, Map.MapGameObjects[(int) InitialPosition.x, (int) InitialPosition.y].transform.position, Quaternion.identity, parent);
		Instance.name = Name;
	}
	#endregion
}
