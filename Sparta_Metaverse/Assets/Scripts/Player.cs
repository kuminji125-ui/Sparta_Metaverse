using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3.0f; // 플레이어 속도
    float h;
    float v;
    private bool isMovingToMouse = false;
    private Vector3 targetPosition;
    Animator anim;
    Rigidbody2D rigid;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        if(h!=0 || v != 0)
        {
            isMovingToMouse = false;
        }
        Vector2 currentInput = Vector2.zero;
        bool isMoving = false;
        if(h!=0 || v != 0)
        {
            currentInput = new Vector2(h, v);
            isMoving = true;
        }else if (isMovingToMouse)
        {
            Vector2 directionToTarget = targetPosition - transform.position;
            if(directionToTarget.magnitude < 0.1f)
            {
                isMovingToMouse = false;
            }
            else
            {
                currentInput = directionToTarget.normalized;
                isMoving = true;
            }
        }
        int animH = 0;
        int animV = 0;
        if (isMoving)
        {
            float absH = Mathf.Abs(currentInput.x);
            float absV = Mathf.Abs(currentInput.y);
            if (absH > absV) { animH = (int)Mathf.Sign(currentInput.x); }
            else if (absV > 0) { animV = (int)Mathf.Sign(currentInput.y); }
        }
        bool hChange = anim.GetInteger("hAxisRaw") != animH;
        bool vChange = anim.GetInteger("vAxisRaw") != animV;
        if (isMoving)
        {
            if (hChange || vChange)
            {
                anim.SetBool("isChange", true);
            }
            else
            {
                anim.SetBool("isChange", false);
            }
            anim.SetInteger("hAxisRaw", animH);
            anim.SetInteger("vAxisRaw", animV);
        }
        else
        {
            if (anim.GetInteger("hAxisRaw") != 0 || anim.GetInteger("vAxisRaw") != 0)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("hAxisRaw", animH);
                anim.SetInteger("vAxisRaw", animV);
            }
            else
            {
                anim.SetBool("isChange", false);
            }
            if (anim.GetInteger("hAxisRaw") != (int)h)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("hAxisRaw", (int)h);
            }
            else if (anim.GetInteger("vAxisRaw") != (int)v)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("vAxisRaw", (int)v);
            }
            else
            {
                anim.SetBool("isChange", false);
            }
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
