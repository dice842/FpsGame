using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//마우스 입력에 따라 카메라 회전
// 속성 : 마우스 입력 X, Y, 속도
// 1. 마우스 입력을 받는다
// 2. 마우스 입력에 따라 회전방향 설정
// 3. 물체를 회전
public class CamRotate : MonoBehaviour
{
    public float speed = 10f;
    float mx = 0;
    float my = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 마우스 입력을 받는다
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mx += mouseX * speed * Time.deltaTime;
        my += mouseY * speed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        Vector3 dir = new Vector3 (-my, mx, 0);

        // 2. 마우스 입력에 따라 회전방향 설정
        // 3. 물체를 회전
        transform.eulerAngles = dir;

    }
}
