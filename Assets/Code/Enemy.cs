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

        Vector2 dirVec = target.position - rigid.position; // Enemy의 방향 = 타겟(player) - enemy현위치
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; 
        rigid.MovePosition(rigid.position + nextVec);  // enemy이동 = player의 키입력 값 + enemy의 방향값
        rigid.velocity = Vector2.zero; // enemy가 player에 부딪혔을때 날아가지 않도록
    }
    
    void LateUpdate()
    {
        if (!isLive)
        { return; }

        spriteRndr.flipX = target.position.x < rigid.position.x; // enemy방향 / enemy.x축뒤집기 = target(player)의 x값 < enemy.x값
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
