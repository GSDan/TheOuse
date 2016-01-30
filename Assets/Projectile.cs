using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public bool Players = true;
    public float Speed = 10;
    public float Lifetime = 10;
    public float Damage = 10;

	// Use this for initialization
	void Start () {

        StartCoroutine(RemoveAfterDelay(Lifetime));
    }

    IEnumerator RemoveAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {

        transform.Translate(Speed * Time.deltaTime, 0, 0);

    }
}
