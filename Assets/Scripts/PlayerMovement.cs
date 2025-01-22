using System;
using UnityEngine;
using UnityEngine.UI;

// �� �ڵ�� ������ Rigidbody2d�� �ʿ�� �ϰ� ������ ���� �޽��� ����
//  �����Ϳ��� ������� ������ ������ ��� ��Ŵ

//  �ش� ��ɸ� ���� �� ��ũ��Ʈ�� ������Ʈ�ν� ����� ��� ���� ���� ������Ʈ��\�� �䱸�ϰ� �˴ϴ�.
//  1. �ش� ������Ʈ�� ���� ��������Ʈ�� ������ ��쿡�� �ڵ����� ������ ������ �ݴϴ�.
//  2. �� ��ũ��Ʈ�� ����� ���¶�� �� ������ư ����� ������Ʈ�� ���� �� �� �����ϴ�.
[RequireComponent(typeof(Rigidbody2D))] 



public class PlayerMovement : MonoBehaviour
{
    public int a = 10;

    public float speed = 2.0f;

    //// double�� �Ǽ��� ǥ���ϴ� �ڷ����̸� �� ��쿡�� f�� ������ �ʴ´�.
    ////  �Ҽ��� 15�ڸ����� ��Ȯ�� ���
    //public double jump_force = 3.5;

    public float jump_force = 3.5f;

    public bool is_jump = false;

    private Rigidbody2D rigid;

    public Text txtOutput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GetComponent<T> - T�� Ÿ��
        //  �ش� ������Ʈ�� ���� ������ ���
        //  T�κп��� ������Ʈ�� ���¸� �ۼ��� �ݴϴ�.
        //  ������Ʈ�� ���°� �ٸ��ٸ� ���� �߻�
        //  �ش� �����Ͱ� �������� ���� ����� null�� ��ȯ�ϰ� �ȴ�.
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
        //  GetAxisRaw("Ű �̸�");�� Input Manager�� Ű�� �����鼭 Ŭ���� ���� -1,0,1�� ��ġ�� ���� ��� �´�.
        //  Ű�� ���� ������ ������ ���
        float x = Input.GetAxisRaw("Horizontal");   //  ���� �̵�, a,dŰ ���
        float y = Input.GetAxisRaw("Vertical");     //  ���� �̵�   w,sŰ ���


        Vector3 velocity = new Vector3(x, y, 0) * speed * Time.deltaTime; //    �ӷ� = ���� * �ӵ�
        gameObject.transform.position += velocity;
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!is_jump) { // ���� ���°� �ƴ� ��� ������ �ٲ۴�.
                is_jump = true;
                rigid.AddForce(Vector3.up * jump_force, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("����");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //  �浹ü�� ���� ������Ʈ�� ���̾ 7�� ������ �� ũ�Ⱑ ���ٸ�
        if (collision.gameObject.layer == 7) {
            is_jump = false;
            Debug.Log("�ٴڰ� �浹");
        }
    }
}
