using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Canvas Canvas;
    public Text Dialogue;
    public EnemySpawner spawner;
    public GameObject EnemyPrefab;

    int currentDialogue = -1;
    bool spawning = false;

    string[] dialogue =
    {
        "This is the first.",
        "Now it's the second, much longer than the first.",
        "I feel asleep",
        "After the fourth is gone, the game will start!!"
    };

    private void AdvanceDialogue()
    {
        currentDialogue++;
        Canvas.enabled = true;
        Dialogue.text = dialogue[currentDialogue];
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (currentDialogue < dialogue.Length - 1)
            {
                AdvanceDialogue();
            }
            else if (!spawning)
            {
                Canvas.enabled = false;
                spawning = true;
                spawner.SpawnEnemies(EnemyPrefab, 15);
            }
        }
    }
}
