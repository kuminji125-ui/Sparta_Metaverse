using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 4f;
    public float followDistance = 1.5f;
    public float followingHeight = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 


    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector3 targetPosition = target.position + new Vector3(0, followingHeight, 0);
        float distance = Vector3.Distance(transform.position, targetPosition);
        if(distance > followDistance)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        }

    }
}
