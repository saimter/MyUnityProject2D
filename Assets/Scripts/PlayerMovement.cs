using System;
using UnityEngine;
using UnityEngine.UI;

// 이 코드는 무조건 Rigidbody2d를 필요로 하고 없을시 에러 메시지 방출
//  에디터에서 등록하지 않으면 강제로 등록 시킴

//  해당 기능를 통해 이 스크립트를 컴포넌트로써 사용할 경우 적어 놓은 컴포넌트ㅇ\를 요구하게 됩니다.
//  1. 해당 컴포넌트가 없는 ㄴ오프젝트에 연결할 경우에는 자동으로 연결을 진행해 줍니다.
//  2. 이 스크립트가 연결된 상태라면 그 오브젝튼 대상의 컴포넌트를 제거 할 수 없습니다.
[RequireComponent(typeof(Rigidbody2D))] 



public class PlayerMovement : MonoBehaviour
{
    public int a = 10;

    public float speed = 2.0f;

    //// double도 실수를 표현하는 자료형이며 이 경우에는 f를 붙이지 않는다.
    ////  소수점 15자리까지 정확히 계산
    //public double jump_force = 3.5;

    public float jump_force = 3.5f;

    public bool is_jump = false;

    private Rigidbody2D rigid;

    public Text txtOutput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GetComponent<T> - T는 타입
        //  해당 컴포넌트의 값을 얻어오는 기능
        //  T부분에는 컴포넌트의 형태를 작성해 줍니다.
        //  컴포넌트의 형태가 다르다면 오류 발생
        //  해당 데이터가 존재하지 않을 경우라면 null을 반환하게 된다.
        rigid = GetComponent<Rigidbody2D>();
        txtOutput.text = "COINS : 100";

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (!is_jump)
        {
            jump();
        }

    }
    private void Move()
    {
        //  GetAxisRaw("키 이름");은 Input Manager의 키를 얻어오면서 클릭에 따라 -1,0,1의 수치로 값을 얻어 온다.
        //  키를 통해 움직일 방향을 계산
        float x = Input.GetAxisRaw("Horizontal");   //  수평 이동, a,d키 사용
        float y = Input.GetAxisRaw("Vertical");     //  수직 이동   w,s키 사용


        Vector3 velocity = new Vector3(x, y, 0) * speed * Time.deltaTime; //    속력 = 방향 * 속도
        gameObject.transform.position += velocity;
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!is_jump) { // 점프 상태가 아닌 경우 점프로 바꾼다.
                is_jump = true;
                rigid.AddForce(Vector3.up * jump_force, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("골인");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //  충돌체의 게임 오브젝트의 레이어가 7과 비교했을 때 크기가 같다면
        if (collision.gameObject.layer == 7) {
            is_jump = false;
            Debug.Log("바닥과 충돌");
        }
    }
}
