using UnityEngine;
using System.Collections;
using System;

public class Enemy_Melee : Unit {

    public Transform Target;
    public float ConvergeDistance = 1.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 thisPos = gameObject.transform.position;
        //Vector3 thisPos = Target.position;

       // float horizVal = (targetPos.x > )

        transform.Translate(0, this.WalkingSpeed * Time.deltaTime, 0);
        transform.Translate(0, this.WalkingSpeed * Time.deltaTime, 0);
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }
}
