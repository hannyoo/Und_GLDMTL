using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid; // r선언 -> r초기화 필요
    SpriteRenderer sprtRndr;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // r초기화
        sprtRndr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() // 물리연산 프레임마다 호출되는 생명주기 함수
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime; // normalized 어느 방향이든지 1의 크기를 줌 * speed * fixedDeltaTime 물리 1 프레임 시간
                                                                  // rigid.AddForce(inputVec);// 1. 힘을 준다
                                                                  // rigid.velocity= inputVec;// 2. velocity 속도 제어
        rigid.MovePosition(rigid.position + nextVec);// 3. 위치 이동
                                                     // MovePosition 위치 이동이기 때문에 현재 위치를 더해주어야함.
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate() // LateUpdate 프레임이 종료되기 전에 실행되는 생명주기 함수
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) // Player 가 이동방향 보기 위함 / 오른쪽 키 inputVec.x = +1
        {
            sprtRndr.flipX = inputVec.x < 0; // 비교 연산자 - inputVec.x < 0 - 좌측을 봄
        }
    }
}
