using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] monsterList;
    public int level;
    public float timeRepeat;
    private static GameManager instance;
    public SummonManager summoner;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)  instance = this; 
        else  Destroy(gameObject);

        level = 1;
        summoner.GetMonsterSet(monsterList);
    }

    // Update is called once per frame
    void Update()
    {
        if (count<=0 || timeRepeat <= 0) {
            summoner.Spawn();
                
        }
        if (timeRepeat > 0)
        {
            timeRepeat -= Time.deltaTime;
        }
    }
}
