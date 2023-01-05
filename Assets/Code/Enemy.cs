using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;

    public Rigidbody2D target;

    bool isLive;
    
    Rigidbody2D rigid;
    SpriteRenderer spriteRndr;

    Animator  anim;

    void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRndr= GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!isLive) 
        { return; }

        Vector2 dirVec = target.position - rigid.position; // Enemy�� ���� = Ÿ��(player) - enemy����ġ
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; 
        rigid.MovePosition(rigid.position + nextVec);  // enemy�̵� = player�� Ű�Է� �� + enemy�� ���Ⱚ
        rigid.velocity = Vector2.zero; // enemy�� player�� �ε������� ���ư��� �ʵ���
    }
    
    void LateUpdate()
    {
        if (!isLive)
        { return; }

        spriteRndr.flipX = target.position.x < rigid.position.x; // enemy���� / enemy.x������� = target(player)�� x�� < enemy.x��
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData spnData)
    {
        anim.runtimeAnimatorController = animCon[spnData.spriteType];
        speed = spnData.speed;
        maxHealth = spnData.health;
        health = spnData.health;
    }

}
