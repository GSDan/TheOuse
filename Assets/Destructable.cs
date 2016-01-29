using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour {

    public int MaxHealth = 100;
    protected int currentHealth;

	// Use this for initialization
	void Start ()
    {
        currentHealth = MaxHealth;
	}
	
    public void Damage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    public virtual void OnDeath()
    {
        // Play death animation + noise
    }

    public void Kill()
    {
        OnDeath();
        Destroy(gameObject);
    }

}
