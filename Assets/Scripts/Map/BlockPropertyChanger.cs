using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPropertyChanger : MonoBehaviour
{
	Renderer rend;

	[HideInInspector] public Material mat;
	[HideInInspector] public Material highlightedMat;
	[HideInInspector] public Material transparentMat;

	[HideInInspector] public bool transparent;

	void Awake()
	{
		rend = transform.GetComponent<MeshRenderer> ();
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter(Collider c)
	{
		Debug.Log ("Entered");
		rend.material = transparentMat;
		transparent = true;
	}

	void OnTriggerExit(Collider c)
	{
		rend.material = mat;
		transparent = false;
	}

	// Use this for initialization
	public void BaseMaterial ()
	{
		if (!transparent)
		{
			rend.material = mat;
		}
	}

	// Use this for initialization
	public void HighlightMaterial ()
	{
		if (!transparent)
		{
			rend.material = highlightedMat;
		}
	}
}
