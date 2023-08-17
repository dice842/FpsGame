using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ű���� �Է¿� ���� ĳ������ �̵�
// �Ӽ� : �̵��ӵ�
// 1. �Է��� �޴´�
// 2. �̵� ������ ����
// 3. �̵� �������� �̵�

// �����̽��� ������ �������� ����

// ���� ������ Ȯ��
public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;

    CharacterController characterController;
    float gravity = -9.8f;
    float yVelocity = 0;
    public float jumpPower = 10;
    public bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (isJumping && characterController.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
        }
        else if (characterController.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0;
        }
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping=true;
        }

        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);

        dir.y = yVelocity;

        yVelocity = yVelocity + gravity * Time.deltaTime;
        //transform.position += dir * speed * Time.deltaTime;

        characterController.Move(dir * speed * Time.deltaTime);
    }
}
