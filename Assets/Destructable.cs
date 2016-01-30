using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour {

    public HealthBar HealthBar;
    public ParticleSystem[] DeathParticles; 
    public int MaxHealth = 100;
    protected float currentHealth;
    protected bool Destroyed = false;

	// Use this for initialization
	void Start ()
    {
        currentHealth = MaxHealth;
	}
	
    public void Damage(float amount)
    {
        currentHealth -= amount;

        HealthBar.SetPercent(currentHealth/MaxHealth);

        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    public virtual void OnDeath()
    {
        // Play death animation + noise
        Destroyed = true;

        if(DeathParticles != null)
        {
            foreach(ParticleSystem ps in DeathParticles)
            {
                ps.Play();
            }
        }

        StartCoroutine(RemoveAfterDelay(10));
    }

    IEnumerator RemoveAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Destroy(gameObject);
    }

    public void Kill()
    {
        OnDeath();
        //Destroy(gameObject);
    }

}
