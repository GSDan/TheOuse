using UnityEngine;
using System.Collections;

public abstract class Unit : Destructable {

    public bool IsEnemy = true;
    public float WalkingSpeed = 1.5f;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public abstract void Attack();
}
