using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class LevelGenerator : MonoBehaviour {

    public Camera Camera;
    public GameObject[] EdgeBarrierPrefabs;
    public GameObject[] PlainGroundPrefabs;
    public Vector2 LevelSize = new Vector2(32, 16);
    public int BarrierWidth = 2;

    private Transform boardPos;
    //private List<Vector3> GridPositions = new List<Vector3>();

    // Use this for initialization
    void Start ()
    {
        createTiles();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void createTiles()
    {
        boardPos = new GameObject("board").transform;

        BarrierWidth = (int)(BarrierWidth * PlainGroundPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x);

        for (float x = -BarrierWidth; x < LevelSize.x + BarrierWidth; x += PlainGroundPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x)
        {
            for (float y = -BarrierWidth; y < LevelSize.y + BarrierWidth; y += PlainGroundPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.y)
            {
                // Get the prefab to create
                GameObject toInstantiate;

                if(x < 0 || x >= LevelSize.x || y < 0 || y >= LevelSize.y)
                {
                    toInstantiate = EdgeBarrierPrefabs[Random.Range(0, EdgeBarrierPrefabs.Length)];
                }
                else
                {
                    toInstantiate = PlainGroundPrefabs[Random.Range(0, PlainGroundPrefabs.Length)];
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardPos);
            }
        }
    }
}
