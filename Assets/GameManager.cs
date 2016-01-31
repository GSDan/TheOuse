using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public class Dialog
    {
        public Sprite head;
        public string line;
    }

    public enum GameState { StartDialogue, Combat, EndDialogue, GameOver };

    public static int EnemiesToKill = 0;

    public GameObject dialoguebox;
    public GameObject gameovermessage;
    public Sprite mainCharHead;
    public Sprite loveHead;
    public Image headPlacement;
    public Text Dialogue;
    public EnemySpawner spawner;
    public GameObject RomanPrefab;
    public GameObject GladPrefab;

    GameState currentState = GameState.StartDialogue;
    bool startedDialogue = false;
    int currentWave = 0;
    int currentDialogue = -1;

    private string[] onDeathMessages = new string[]
    {
        "That awkward moment when you die because you tried to seduce a woman",
        "Always a virgin, always a victim",
        "Teddy died before he could pop his crucial cherry",
        "Teddy died doing what he loved: fighting hordes of the undead in an attempt to get laid",
        "Wow, really impressed her there, mate",
    };

    private string[] onTargetDestroyedMessages = new string[]
    {
        "The Minster was destroyed. So was Bettina. Nice job, Teddy.",
        "That awkward moment where you accidentally get your lass killed by hordes of the undead",
        "Bettina died along with the destruction of the Minster and presumably the human race",
        "Teddy had better slink into the night before the fuzz arrives- his lass is dead and zombies are everywhere",
        "Wow, she's dead. The Minster is destroyed. Good one, dude.",
    };

    private Wave[] waves;

    private void AdvanceDialogue()
    {
        currentDialogue++;
        dialoguebox.SetActive(true);
        
        Dialogue.text = (currentState == GameState.StartDialogue)? 
            waves[currentWave].StartDialogue[currentDialogue].line : waves[currentWave].EndDialogue[currentDialogue].line;

        headPlacement.sprite = (currentState == GameState.StartDialogue) ?
            waves[currentWave].StartDialogue[currentDialogue].head : waves[currentWave].EndDialogue[currentDialogue].head;
    }

    // Use this for initialization
    void Start() {
        waves = new Wave[]
        {
                new Wave
                {
                    StartDialogue = new Dialog[]
                    {
                        new Dialog {line = "What are those hideous creatures emerging from the Ouse?", head = mainCharHead },
                        new Dialog {line = "Teddy, is this your fault? I hate you.", head = loveHead },
                        new Dialog {line = "Oh fiddlesticks. I am the worst necromancer ever.", head = mainCharHead },
                        new Dialog {line = "I can't let them get to the Minster. I must protect bae by pressing SPACE to summon my magic goo.", head = mainCharHead },
                    },
                    EndDialogue = new Dialog[]
                    {
                         new Dialog {line = "I am so grounded.", head = mainCharHead },
                         new Dialog {line = "This is the worst prom night ever.", head = loveHead },
                    },
                    Mobs = new MobSpawnEvent[]
                    {
                        new MobSpawnEvent
                        {
                            EnemyPrefab = RomanPrefab,
                            Num = 3
                        },
                        new MobSpawnEvent
                        {
                            EnemyPrefab = GladPrefab,
                            Num = 3
                        }
                    }
                },
                new Wave
                {
                    StartDialogue = new Dialog[]
                    {
                        new Dialog {line = "This is getting stupid. There are even more of them!", head = mainCharHead },
                        new Dialog {line = "I am never going to attempt to impress a girl again. I will live the celibate life of a computer science student.", head = mainCharHead },
                        new Dialog {line = "Well, they are generally very attractive.", head = loveHead },
                    },
                    EndDialogue = new Dialog[]
                    {
                        new Dialog {line = "Suck it, undead fools.", head = mainCharHead },
                    },
                    Mobs = new MobSpawnEvent[]
                    {
                        new MobSpawnEvent
                        {
                            EnemyPrefab = RomanPrefab,
                            Num = 15
                        },
                        new MobSpawnEvent
                        {
                            EnemyPrefab = GladPrefab,
                            Num = 2
                        }
                    }
                },
                new Wave
                {
                    StartDialogue = new Dialog[]
                    {
                        new Dialog {line = "Stay inside, Bettina! I shall defend your innocence from this ungodly horde", head = mainCharHead },
                        new Dialog {line = "What innocence? I mean, uh, ok.", head = loveHead },
                    },
                    EndDialogue = new Dialog[]
                    {
                        new Dialog {line = "You continue to be safe, my succulent little blossom.", head = mainCharHead },
                    },
                    Mobs = new MobSpawnEvent[]
                    {
                        new MobSpawnEvent
                        {
                            EnemyPrefab = RomanPrefab,
                            Num = 25
                        },
                        new MobSpawnEvent
                        {
                            EnemyPrefab = GladPrefab,
                            Num = 3
                        }
                    }
                },
                new Wave
                {
                    StartDialogue = new Dialog[]
                    {
                        new Dialog {line = "This looks like a big one. Which, incidentally, is what I'll be saying later.", head = mainCharHead },
                        new Dialog {line = "Not if they tear your head off.", head = loveHead },
                    },
                    EndDialogue = new Dialog[]
                    {
                        new Dialog {line = "Bettina! We've done it. I'm not the world's worst necromancer anymore!", head = mainCharHead },
                        new Dialog {line = "Yeah, maybe just the second worst. Good enough for me.", head = loveHead },
                    },
                    Mobs = new MobSpawnEvent[]
                    {
                        new MobSpawnEvent
                        {
                            EnemyPrefab = RomanPrefab,
                            Num = 32
                        },
                        new MobSpawnEvent
                        {
                            EnemyPrefab = GladPrefab,
                            Num = 3
                        }
                    }
                }
        };
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (currentWave >= waves.Length)
        {
            SceneManager.LoadScene(3);
            return;
        }

        if (currentState == GameState.GameOver) return;

        Wave thisWave = waves[currentWave];

        if (Input.GetKeyUp(KeyCode.E) || (currentState == GameState.Combat && EnemiesToKill == 0) || !startedDialogue)
        {
            if(!startedDialogue && currentState == GameState.StartDialogue && currentDialogue < thisWave.StartDialogue.Length - 1)
            {
                startedDialogue = true;
                AdvanceDialogue();
                return;
            }
            else if (Input.GetKeyUp(KeyCode.E) && currentState == GameState.StartDialogue && currentDialogue < thisWave.StartDialogue.Length - 1)
            {
                AdvanceDialogue();
                return;
            }

            if (currentState == GameState.Combat && EnemiesToKill <= 0)
            {
                currentState = GameState.EndDialogue;
            }

            if(!startedDialogue && currentState == GameState.EndDialogue && currentDialogue < thisWave.EndDialogue.Length - 1)
            {
                startedDialogue = true;
                AdvanceDialogue();
                return;
            }
            else if (Input.GetKeyUp(KeyCode.E) && currentState == GameState.EndDialogue && currentDialogue < thisWave.EndDialogue.Length - 1)
            {
                AdvanceDialogue();
                return;
            }
            else if(Input.GetKeyUp(KeyCode.E) && currentState == GameState.EndDialogue)
            {
                startedDialogue = false;
                currentDialogue = -1;
                currentWave++;
                currentState = GameState.StartDialogue;
                return;
            }

            if (currentState != GameState.Combat)
            {
                currentState = GameState.Combat;
                currentDialogue = -1;
                dialoguebox.SetActive(false);
                EnemiesToKill = 0;
                startedDialogue = false;

                foreach (MobSpawnEvent mobs in thisWave.Mobs)
                {
                    EnemiesToKill += mobs.Num;
                }

                spawner.SpawnEnemies(thisWave.Mobs);
            }
        }
    }

    public void PlayerDied ()
    {
        string message = onDeathMessages[Random.Range(0, onDeathMessages.Length-1)];
        gameovermessage.SetActive(true);
        gameovermessage.GetComponent<Text>().text = message;
        currentState = GameState.GameOver;
        StartCoroutine(EndGame(5));
    }

    public void TargetDestroyed ()
    {
        string message = onTargetDestroyedMessages[Random.Range(0, onTargetDestroyedMessages.Length - 1)];
        gameovermessage.SetActive(true);
        gameovermessage.GetComponent<Text>().text = message;
        currentState = GameState.GameOver;
        StartCoroutine(EndGame(5));
    }

    IEnumerator EndGame(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        SceneManager.LoadScene(1);
    }
}
