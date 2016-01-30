using UnityEngine;

public class CameraManager : MonoBehaviour {

    
    public GameObject Follow;

    

	// Use this for initialization
	void Start () {
	
	}

    
	
	// Update is called once per frame
	void Update () {

        Vector3 newPos = new Vector3(Follow.transform.position.x, Follow.transform.position.y, transform.position.z);

        transform.position = newPos;
	}
}
