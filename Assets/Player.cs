using UnityEngine;
using System.Collections;
using System;

public class Player : Unit {

    public Transform ProjectilePoint;
    public GameObject ProjectilePrefab;
    public GameManager GameManager;
    public float AttackCooldown = 0.3f;
    bool attacking = false;
    float direction;

    // Use this for initialization
    void Start ()
    {
        currentHealth = MaxHealth;
        direction = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Destroyed)
        {
            return;
        }
        CheckMovement();
	}

    private void CheckMovement()
    {
        bool walking = false;

        if(Input.GetKeyUp(KeyCode.Space) && !attacking)
        {
            Attack(null);
            return;
        }
        if(attacking)
        {
            return;
        }

        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            walking = true;
            transform.Translate(0, this.WalkingSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            walking = true;
            transform.Translate(0, -this.WalkingSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            walking = true;
            transform.Translate(this.WalkingSpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(direction, transform.localScale.y);
        }
        else if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            walking = true;
            transform.Translate(-this.WalkingSpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(-direction, transform.localScale.y);
        }

        Anim.SetBool("Walking", walking);
    }

    public override void Attack(Destructable target)
    {
        Anim.SetBool("Attacking", true);
        attacking = true;
        StartCoroutine(AttackDelay(AttackCooldown));

        GameObject projectile = (GameObject)Instantiate(ProjectilePrefab, ProjectilePoint.position, Quaternion.identity);
        Projectile proj = projectile.GetComponent<Projectile>();

        proj.Speed = (transform.localScale.x > 0) ? proj.Speed : -proj.Speed; 

    }

    IEnumerator AttackDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Anim.SetBool("Attacking", false);
        attacking = false;
    }

    public override void OnDeath()
    {
        base.OnDeath();
        Anim.SetTrigger("Death");
        Destroy(HealthBar.gameObject);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        GameManager.PlayerDied();
    }
}
