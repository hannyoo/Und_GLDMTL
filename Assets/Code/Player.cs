using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid; // r���� -> r�ʱ�ȭ �ʿ�
    SpriteRenderer sprtRndr;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // r�ʱ�ȭ
        sprtRndr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() // �������� �����Ӹ��� ȣ��Ǵ� �����ֱ� �Լ�
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime; // normalized ��� �����̵��� 1�� ũ�⸦ �� * speed * fixedDeltaTime ���� 1 ������ �ð�
                                                                  // rigid.AddForce(inputVec);// 1. ���� �ش�
                                                                  // rigid.velocity= inputVec;// 2. velocity �ӵ� ����
        rigid.MovePosition(rigid.position + nextVec);// 3. ��ġ �̵�
                                                     // MovePosition ��ġ �̵��̱� ������ ���� ��ġ�� �����־����.
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate() // LateUpdate �������� ����Ǳ� ���� ����Ǵ� �����ֱ� �Լ�
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) // Player �� �̵����� ���� ���� / ������ Ű inputVec.x = +1
        {
            sprtRndr.flipX = inputVec.x < 0; // �� ������ - inputVec.x < 0 - ������ ��
        }
    }
}
