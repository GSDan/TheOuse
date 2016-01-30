using UnityEngine;
using System.Collections;
using System;

public class Player : Unit {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckMovement();
	}

    private void CheckMovement()
    {
        if (Input.GetKey("up"))
        {
            transform.Translate(0, this.WalkingSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey("down"))
        {
            transform.Translate(0, -this.WalkingSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey("right"))
        {
            transform.Translate(this.WalkingSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("left"))
        {
            transform.Translate(-this.WalkingSpeed * Time.deltaTime, 0, 0);
        }
    }

    public override void Attack(Destructable target)
    {
        throw new NotImplementedException();
    }
}
