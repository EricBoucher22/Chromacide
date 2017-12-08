using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
	#region private variables
	[SerializeField] private string _name;
	[SerializeField] private AffinityColor _affinityColor;
	[SerializeField] private Vector2 _initialTile;
	[SerializeField] private GameObject _model;
	private GameObject _instance;
	#endregion

	#region constructors
	public Character (string name, AffinityColor affinityColor, Vector3 initialTile, GameObject model, GameObject instance)
	{
		_affinityColor = affinityColor;
		_name = name;
		_initialTile = initialTile;
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

	public AffinityColor AffinityColor
	{
		get
		{
			return _affinityColor;
		}
		set
		{
			_affinityColor = value;
		}
	}

	public Vector3 InitialTile
	{
		get
		{
			return _initialTile;
		}
		set
		{
			_initialTile = value;
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
		Instance = GameObject.Instantiate (Model, Map.MapGameObjects[(int) InitialTile.x, (int) InitialTile.y].transform.position, Quaternion.identity, parent);
		Instance.name = Name;
	}
	#endregion
}
