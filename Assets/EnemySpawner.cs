using UnityEngine;
using System.Collections;
using Assets;

public class EnemySpawner : MonoBehaviour {

    public Destructable Target;
    private MobSpawnEvent[] Mobs;
    private int EnemiesToSpawn = 0;
    private int enemiesSpawned = 0;
    private int typesSpawned = 0;

    public float MinY = 2;
    public float MaxY = 14;
    public float MaxSpawnDelaySecs = 3;
    public float MinSpawnDelaySecs = 0;

    private float TimeSinceLastSpawn = 0;
    private float NextSpawnDelay = 0;

	// Use this for initialization
	void Start ()
    {
        NextSpawnDelay = Random.Range(MinSpawnDelaySecs, MaxSpawnDelaySecs);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Mobs == null || typesSpawned >= Mobs.Length) return;

        TimeSinceLastSpawn += Time.deltaTime;

        if(TimeSinceLastSpawn >= NextSpawnDelay)
        {
            NextSpawnDelay = Random.Range(MinSpawnDelaySecs, MaxSpawnDelaySecs);
            TimeSinceLastSpawn = 0;

            SpawnEnemy();
        }
    }

    public void SpawnEnemies(MobSpawnEvent[] given)
    {
        Mobs = given;
        typesSpawned = 0;
        enemiesSpawned = 0;
        TimeSinceLastSpawn = 0;
    }

    private void SpawnEnemy()
    {
        float YLoc = Random.Range(MinY, MaxY);

        GameObject enemy = (GameObject)Instantiate(Mobs[typesSpawned].EnemyPrefab, new Vector3(transform.position.x, YLoc, 0), Quaternion.identity);

        enemy.GetComponent<Enemy_Melee>().Target = Target;

        enemiesSpawned++;

        if(enemiesSpawned >= Mobs[typesSpawned].Num)
        {
            typesSpawned++;
            enemiesSpawned = 0;
        }
    }
}
