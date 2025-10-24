using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4.0f; // 플레이어 속도
    float h;
    float v;
    private bool isMovingToMouse = false;
    private Vector3 targetPosition;

    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;
            isMovingToMouse = true;
        }
        if (h != 0 || v != 0)
        {
            isMovingToMouse = false;
        }
    }

    private void FixedUpdate()
    {
        if (isMovingToMouse)
        {
            Vector2 direction = targetPosition - transform.position;
            if(direction.magnitude < 0.1f)
            {
                isMovingToMouse = false;
                rigid.velocity = Vector2.zero;
            }
            else
            {
                direction.Normalize();
                rigid.velocity = direction * moveSpeed;
            }
        }
        else
        {
            rigid.velocity = new Vector2(h * moveSpeed, v * moveSpeed);
        }     
    }
}
