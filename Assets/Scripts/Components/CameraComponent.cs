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

	public void RotateCamera(int angle)
	{
		transform.Rotate (new Vector3 (0, angle, 0));
	}
}
