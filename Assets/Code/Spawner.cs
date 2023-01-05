using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;
    float timer;
        
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f),spawnData.Length -1); // FloorToInt 소수점 아래는 버리고 int형으로 바꾸는 함수

        if (timer > spawnData[level].spawnTime)
        {           
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
       GameObject enemy = GameManager.instance.poolManager.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

[System.Serializable] // 직렬화
public class SpawnData
{
    public float spawnTime;
    public int spriteType;   
    public int health;
    public float speed;
}