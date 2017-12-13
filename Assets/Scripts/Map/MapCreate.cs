using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class MapCreate : MonoBehaviour
{
	[SerializeField] private GameObject ground = null;
	[SerializeField] private GameObject wall = null;
	[SerializeField] private GameObject half_wall = null;
	[SerializeField] private GameObject hole = null;
	[SerializeField] private Material[] materials = null;
	[SerializeField] private Material[] highlightedMaterials = null;
	[SerializeField] private Material neutralMaterial = null;

	public static Vector3 PositionReference;

	void Awake()
	{
		Map.NeutralMaterial = neutralMaterial;
		Map.Materials = materials;
		Map.HighlightedMaterials = highlightedMaterials;

		Map.CreateMapArray ();
		Map.CreateMapTiles (ground, wall, half_wall, hole, transform.position, transform);
		PositionReference = transform.position;
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
