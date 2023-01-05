using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        { return; }

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x); //플레이어 위치에서 타일맵 위치를 뺴서 거리 구함
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
        // 3항연산자 (조건) ? (true일때 값) : (false일때 값)

        switch(transform.tag)
        {
            case "Ground":
                if(diffX > diffY)               //플레이어가 엑스축에서 멀어졌을 때 타일도 따라오도록
                {           
                    transform.Translate(Vector3.right*dirX * 40); //Translate 지정된 값만큼 현재 위치에서 이동
                }
                else if (diffX < diffY)               //플레이어가 y축에서 멀어졌을 때 타일도 따라오도록
                {
                    transform.Translate(Vector3.up * dirY * 40); 
                }
                break;

            case "Enemy":
                if (coll.enabled) //콜라이더가 비활성일때
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3F,3F), Random.Range(-3F, 3F),0F)); // player의 맞은 편에서 등장
                }
                break;

        }

    }
}
