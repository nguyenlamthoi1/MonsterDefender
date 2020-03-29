using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class SummonManager : MonoBehaviour
{
    public GameManager gameManager; 

    public int levelFirstSpawn;
    public int currentLevel;
    public int quantityToSpawn;
    public float t;
    public class MonsterInfo
    {
        
        public GameObject monster;
        public int spawnRate;
        public MonsterInfo(GameObject monster)
        {
            this.monster = monster;
        }
        public MonsterInfo(GameObject monster,int spawnRate)
        {
            this.monster = monster;
            this.spawnRate = spawnRate;
        }
    }
    public Transform[] summonPlaceList;
    public List<MonsterInfo> MonsterSet;

    public void GetMonsterSet(GameObject[] list)
    {
        MonsterSet = new List<MonsterInfo>();
        levelFirstSpawn = 1;
        quantityToSpawn = 3;
        bool firstMonsterChosen = false;
        foreach (GameObject monster in list)
        {
            if (!firstMonsterChosen)
            {
                firstMonsterChosen = true;
                MonsterSet.Add(new MonsterInfo(monster, 100));

            }
            MonsterSet.Add(new MonsterInfo(monster));
        }
    }
    
    public void Spawn()
    {
        //summoning...
        int[] buffer = new int[4] ;
        int num = quantityToSpawn;
        foreach (MonsterInfo monster in MonsterSet)
        {
            int numRespawn = num * monster.spawnRate / 100;
            num -= numRespawn;
            //print("respawn" + monster.monster + " with num =" + numRespawn);
            for (int i = 0; i < numRespawn; i++) {
                int summonPlaceIndex = Random.Range(0, summonPlaceList.Length);
                buffer[summonPlaceIndex]++;

                Vector3 pos = summonPlaceList[summonPlaceIndex].position;
                if (summonPlaceIndex == 0)
                    pos -= new Vector3(buffer[summonPlaceIndex], 0, 0);
                if (summonPlaceIndex == 1)
                    pos += new Vector3(0, buffer[summonPlaceIndex], 0);
                if (summonPlaceIndex == 2)
                    pos += new Vector3(buffer[summonPlaceIndex], 0, 0);
                if (summonPlaceIndex == 3)
                    pos -= new Vector3(0, buffer[summonPlaceIndex], 0);

                Instantiate(monster.monster, pos, Quaternion.identity);
            }
           
        }
        //fix spawn Rate
        bool firstLess50 = false;
        foreach (MonsterInfo monster in MonsterSet)
        {

            if (monster.spawnRate > 50)
            {
                monster.spawnRate -= 10;
            }
            else
            {
                if (firstLess50) break;
                firstLess50 = true;
                monster.spawnRate += 10;
            }
          

            
            //update quantity to spawn
            gameManager.count += quantityToSpawn;
            quantityToSpawn = (int)Mathf.Round(quantityToSpawn * t);
            currentLevel++;
            //update current number of monsters
            
        }
    }
}
