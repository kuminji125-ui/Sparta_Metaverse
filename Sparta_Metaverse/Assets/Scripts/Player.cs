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
    public GameObject scanObject;
    Vector3 dirVec;
    public GameManager manager;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        h = manager.isAction ? 0: Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0: Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");
        if (!manager.isAction&&Input.GetMouseButtonDown(0)) //마우스 클릭 이동
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;
            isMovingToMouse = true;
        }
        if(manager.isAction && isMovingToMouse)
        {
            isMovingToMouse = false;
            rigid.velocity = Vector2.zero;
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
                rigid.velocity = Vector2.zero;
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
        bool directionChanging = anim.GetInteger("hAxisRaw") != animH || anim.GetInteger("vAxisRaw") != animV;
        if (directionChanging)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", animH);
            anim.SetInteger("vAxisRaw",animV);
        }
        else
        {
            anim.SetBool("isChange", false);
        }
        if (isMovingToMouse)
        {
            float absH = Mathf.Abs(currentInput.x);
            float absV = Mathf.Abs(currentInput.y);
            if(absH > absV)
            {
                dirVec = currentInput.x > 0 ? Vector3.right : Vector3.left;
            }
            else
            {
                dirVec = currentInput.y > 0 ? Vector3.up : Vector3.down;
            }
        }
        else
        {
            if (hDown && h == 1)
            {
                dirVec = Vector3.right;
            }
            else if (hDown && h == -1)
            {
                dirVec = Vector3.left;
            }
            else if (vDown && v == 1)
            {
                dirVec = Vector3.up;
            }
            else if (vDown && v == -1)
            {
                dirVec = Vector3.down;
            }
        }
        //scanObject
        if (Input.GetButtonDown("Jump")&& scanObject != null)//spacebar
        {
            manager.Action(scanObject);
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
        Debug.DrawRay(rigid.position, dirVec *0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
        if(rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
