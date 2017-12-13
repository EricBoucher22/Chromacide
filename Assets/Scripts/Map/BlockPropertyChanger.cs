using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPropertyChanger : MonoBehaviour
{
	Renderer rend;

	[HideInInspector] public Material mat;
	[HideInInspector] public Material highlightedMat;

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

	// Use this for initialization
	public void BaseMaterial ()
	{
		rend.material = mat;
	}

	// Use this for initialization
	public void HighlightMaterial ()
	{
		rend.material = highlightedMat;
	}
}
