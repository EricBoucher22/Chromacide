using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public enum CellType { Ground, Wall, Half_Wall, Hole };

public struct Cell
{
	public Vector2 ArrayPosition;
	public List<AffinityColor> Colors;
	public CellType Type;

	public GameObject Model;
}

public class Map
{
	public static float[] TileCost = { 1, 1, 1, 1 };
	public static Cell[,] MapArray;

	public static GameObject[,] MapGameObjects;

	public static Material NeutralMaterial;
	public static Material[] Materials;
	public static Material[] HighlightedMaterials;
	public static Material[] TransparentMaterials;

	public static int[,] MapTypeTemp =
	{
		//i\j  0, 1, 2, 3, 4, 5, 6, 7, 8 ,9
		/*0*/ {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
		/*1*/ {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		/*2*/ {0, 0, 0, 0, 0, 0, 0, 1, 1, 1},
		/*3*/ {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		/*4*/ {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		/*5*/ {0, 0, 0, 1, 1, 1, 0, 0, 0, 0},
		/*6*/ {0, 0, 0, 1, 1, 1, 0, 3, 3, 3},
		/*7*/ {2, 2, 0, 1, 1, 1, 0, 0, 0, 0},
		/*8*/ {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		/*9*/ {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
	};

	public static string[,] MapColorTemp =
	{
		//K=black, R=red,G=green,B=blue,  = vide
		//i\j	0,		1,		2,		3,		4,		5,		6,		7,		8,		9
		/*0*/ {	"KRGB",	"KRGB",	"KRGB",	"KRGB", "KRGB", "KRGB", "KRGB", "----", "KRGB", "KRGB"},
		/*1*/ {	"KRGB",	"KRGB",	"KRGB",	"KRGB", "KRGB", "KRGB", "KRGB", "KRGB", "KRGB", "KRGB"}, // (il y a la porte où tout le monde peut passer mais faut l'ouvrir)
		/*2*/ {	"KRGB",	"KRGB",	"KRGB",	"KRGB", "KRGB", "KRGB", "KR-B", "----", "----", "----"},
		/*3*/ {	"KRGB",	"KRGB",	"KRGB",	"KRGB", "KRGB", "KRGB", "KRGB", "KRGB", "KRGB", "KRGB"},
		/*4*/ {	"KRGB",	"KRGB",	"KRGB",	"KRGB", "KRGB", "KRGB", "KRGB", "KRGB", "KRGB", "KRGB"},
		/*5*/ {	"KRGB",	"KRGB",	"KRGB",	"----", "-R--", "----", "KRGB", "KRGB", "KRGB", "KRGB"},
		/*6*/ {	"KRGB",	"KRGB",	"KRGB",	"----", "-R--", "----", "KRGB", "----", "---B", "----"},
		/*7*/ {	"----",	"----",	"KRGB",	"----", "-R--", "----", "KRGB", "KRGB", "KRGB", "KRGB"},
		/*8*/ {	"KRGB",	"KRGB",	"KRGB",	"KRGB", "KRGB", "KRGB", "KRGB", "KRGB", "KRGB", "KRGB"},
		/*9*/ {	"KRGB",	"KRGB",	"KRGB",	"KRGB", "KRGB", "KRGB", "KRGB", "KRGB", "KRGB", "KRGB"}
	};

	public static void CreateMapArray()
	{
		CreateMapArray (MapColorTemp, MapTypeTemp);
	}

	public static void CreateMapArray(string[,] MapColor, int[,] MapType)
	{
		int height = MapColor.GetLength (0);
		int width = MapColor.GetLength (1);
		MapArray = new Cell[height, width];
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				MapArray [i, j] = new Cell ();
				MapArray [i, j].ArrayPosition = new Vector2 (i, j);
				MapArray [i, j].Colors = new List<AffinityColor> ();
				foreach (char c in MapColor [i, j])
				{
					switch (c)
					{
						case 'K':
							MapArray [i, j].Colors.Add ((AffinityColor.Black));
							break;
						case 'R':
							MapArray [i, j].Colors.Add ((AffinityColor.Red));
							break;
						case 'G':
							MapArray [i, j].Colors.Add ((AffinityColor.Green));
							break;
						case 'B':
							MapArray [i, j].Colors.Add ((AffinityColor.Blue));
							break;
					}

				}
				MapArray [i, j].Type = (CellType) Enum.ToObject(typeof(CellType), MapType [i, j]);
			}
		}
	}

	// Use this for initialization
	public static void CreateMapTiles (GameObject ground, GameObject wall, GameObject half_wall, GameObject hole, Vector3 PositionStarter, Transform transform)
	{
		int height = MapArray.GetLength (0);
		int width = MapArray.GetLength (1);

		MapGameObjects = new GameObject[width, height];
		// create map tiles
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				int type = (int) MapArray [i, j].Type;
				switch ((CellType)type)
				{
					case CellType.Ground:
						MapGameObjects [i, j] = GameObject.Instantiate (ground, PositionStarter + new Vector3 (j, 0, -i), Quaternion.Euler (Vector3.zero), transform);
						break;
					case CellType.Wall:
						MapGameObjects[i, j] = GameObject.Instantiate (wall, PositionStarter + new Vector3(j, 0, -i), Quaternion.Euler(Vector3.zero), transform);
						break;
					case CellType.Half_Wall:
						MapGameObjects[i, j] = GameObject.Instantiate (half_wall, PositionStarter + new Vector3 (j, 0, -i), Quaternion.Euler (Vector3.zero), transform);
						break;
					case CellType.Hole:
						MapGameObjects[i, j] = GameObject.Instantiate (hole, PositionStarter + new Vector3 (j, 0, -i), Quaternion.Euler (Vector3.zero), transform);
						break;
				}
				MapGameObjects [i, j].name = "Block " + i.ToString () + ", " + j.ToString ();
			}
		}
	}

	public static void ActivateColor(AffinityColor color)
	{
		int height = MapArray.GetLength (0);
		int width = MapArray.GetLength (1);

		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				BlockCharacterMovement blockCharacterMovement = MapGameObjects [i, j].GetComponentInChildren<BlockCharacterMovement> ();
				BlockPropertyChanger blockPropertyChanger = MapGameObjects [i, j].GetComponentInChildren<BlockPropertyChanger> ();
				NavMeshObstacle navMeshObstacle = MapGameObjects [i, j].GetComponentInChildren<NavMeshObstacle> ();

				if (navMeshObstacle != null)
				{
					navMeshObstacle.enabled = true;
				}
				blockCharacterMovement.enabled = false;
				blockPropertyChanger.mat = NeutralMaterial;
				blockPropertyChanger.highlightedMat = NeutralMaterial;
				blockPropertyChanger.transparentMat = NeutralMaterial;
				foreach (AffinityColor c in MapArray [i, j].Colors)
				{
					int index_color = (int) c;
					if (c == color)
					{
						if (navMeshObstacle != null)
						{
							navMeshObstacle.enabled = false;
						}
						blockCharacterMovement.enabled = true;
						blockPropertyChanger.mat = Materials [index_color];
						blockPropertyChanger.highlightedMat = HighlightedMaterials [index_color];
						blockPropertyChanger.transparentMat = TransparentMaterials [index_color];
					}
				}
				blockPropertyChanger.BaseMaterial ();
			}
		}
	}
}
