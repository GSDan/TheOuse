using UnityEngine;
using System.Collections;
using System;

public class Enemy_Melee : Unit {

    public Destructable Target;
    public float ConvergeDistance = 1.0f;
    public float AttackRange = 0.5f;
    public int AttackPower = 10;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        try
        {
            if(Target == null)
            {
                if(!Destroyed) OnDeath();
                return;
            }

            Vector3 thisPos = gameObject.transform.position;
            Vector3 targetPos = Target.transform.position;

            float horizVal = 0;
            float vertVal = 0;

            if (Math.Abs(targetPos.x - thisPos.x) > AttackRange)
            {
                horizVal = (targetPos.x > thisPos.x + AttackRange) ? this.WalkingSpeed : -this.WalkingSpeed;
            }
            else if (Math.Abs(targetPos.y - thisPos.y) <= AttackRange)
            {
                // We're within attack range! Stop moving!
                Attack(Target);
                return;
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

            Anim.SetBool("Attacking", false);
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
        }
        
    }

    public override void OnDeath()
    {
        base.OnDeath();
        Anim.SetTrigger("Death");
    }

    public override void Attack(Destructable target)
    {
        target.Damage(AttackPower * Time.deltaTime);
        Anim.SetBool("Attacking", true);
    }
}
