using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] monsterList;
    public int level;
    public float timeRepeat;
    public float timer;
    private static GameManager instance;
    public SummonManager summoner;
    public int count;
    public bool spawning = false;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)  instance = this; 
        else  Destroy(gameObject);
        timer = timeRepeat;
        level = 1;
        summoner.GetMonsterSet(monsterList);
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {

            if (!spawning)
            {
                spawning = true;
                print("spawn from count: " + timeRepeat);
                Invoke("Spawn", 2f);
            }  
        }
           
        else if (timer <= 0)
        {
            timer = timeRepeat;
            print("spawn from timerepeat: "+timeRepeat);
            Invoke("Spawn", 0);
        }

        else {
           
            timer -= Time.deltaTime; }
    }
    void Spawn() {
        summoner.Spawn();
    }
}
