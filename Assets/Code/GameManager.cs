using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 메모리에 올림
    public static GameManager instance; // 선언

    public float gameTime;
    public float maxGameTime = 2 * 10f; // 2* 10초



    public Player player;
    public PoolManager poolManager;

    void Awake()
    {
        instance = this; // 정의
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
