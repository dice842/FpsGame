using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 키보드 입력에 따른 캐릭터의 이동
// 속성 : 이동속도
// 1. 입력을 받는다
// 2. 이동 방향을 설정
// 3. 이동 방향으로 이동

// 스페이스를 누르면 수직으로 점프

// 점프 중인지 확인
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
