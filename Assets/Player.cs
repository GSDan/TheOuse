using UnityEngine;
using System.Collections;
using System;

public class Player : Unit {

    public float AttackCooldown = 0.3f;
    bool attacking = false;

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
        bool walking = false;

        if(Input.GetKey(KeyCode.Space) && !attacking)
        {
            Attack(null);
            return;
        }
        if(attacking)
        {
            return;
        }


        if (Input.GetKey("up"))
        {
            walking = true;
            transform.Translate(0, this.WalkingSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey("down"))
        {
            walking = true;
            transform.Translate(0, -this.WalkingSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey("right"))
        {
            walking = true;
            transform.Translate(this.WalkingSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("left"))
        {
            walking = true;
            transform.Translate(-this.WalkingSpeed * Time.deltaTime, 0, 0);
        }

        Anim.SetBool("Walking", walking);
    }

    public override void Attack(Destructable target)
    {
        Anim.SetBool("Attacking", true);
        attacking = true;
        StartCoroutine(AttackDelay(AttackCooldown));
    }

    IEnumerator AttackDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Anim.SetBool("Attacking", false);
        attacking = false;
    }
}
