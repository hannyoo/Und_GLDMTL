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
        float diffX = Mathf.Abs(playerPos.x - myPos.x); //�÷��̾� ��ġ���� Ÿ�ϸ� ��ġ�� ���� �Ÿ� ����
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
        // 3�׿����� (����) ? (true�϶� ��) : (false�϶� ��)

        switch(transform.tag)
        {
            case "Ground":
                if(diffX > diffY)               //�÷��̾ �����࿡�� �־����� �� Ÿ�ϵ� ���������
                {           
                    transform.Translate(Vector3.right*dirX * 40); //Translate ������ ����ŭ ���� ��ġ���� �̵�
                }
                else if (diffX < diffY)               //�÷��̾ y�࿡�� �־����� �� Ÿ�ϵ� ���������
                {
                    transform.Translate(Vector3.up * dirY * 40); 
                }
                break;

            case "Enemy":
                if (coll.enabled) //�ݶ��̴��� ��Ȱ���϶�
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3F,3F), Random.Range(-3F, 3F),0F)); // player�� ���� ���� ����
                }
                break;

        }

    }
}
