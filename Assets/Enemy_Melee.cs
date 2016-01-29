using UnityEngine;
using System.Collections;
using System;

public class Enemy_Melee : Unit {

    public Transform Target;
    public float ConvergeDistance = 1.0f;
    public float AttackRange = 0.5f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 thisPos = gameObject.transform.position;
        Vector3 targetPos = Target.position;

        float horizVal = 0;
        float vertVal = 0;

        if (Math.Abs(targetPos.x - thisPos.x) > AttackRange)
        {
            horizVal = (targetPos.x > thisPos.x + AttackRange) ? this.WalkingSpeed : -this.WalkingSpeed;
        }

        // Only worry about vert if within converge distance
        if (Math.Abs(targetPos.x - thisPos.x) <= ConvergeDistance)
        {
            if (Math.Abs(targetPos.y - thisPos.y) > AttackRange)
            {
                vertVal = (targetPos.y > thisPos.y + AttackRange) ? this.WalkingSpeed : -this.WalkingSpeed;
            }
        }

        transform.Translate(horizVal * Time.deltaTime, 0, 0);
        transform.Translate(0, vertVal * Time.deltaTime, 0);
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }
}
