using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour, IInputHandler
{
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void InputSend(string method, object param)
	{
		if (method.Equals ("RotateCamera"))
		{
			transform.Rotate (new Vector3 (0, (int) param, 0));
		}
	}
}
