using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathControlAlt : MonoBehaviour
{
    [SerializeField]
    public PathManager pathManager;
    public Animator animator;
    bool isWalking;
    bool isIdle;

    List<Waypoint> thePath;
    Waypoint target;

    public float MoveSpeed;
    public float RotateSpeed;

    void Start()
    {
        isWalking = false;
        animator.SetBool("isWalking", isWalking);

        thePath = pathManager.GetPath();
        if (thePath != null && thePath.Count > 0)
        {
            target = thePath[0];
        }
    }

    void rotateTowardsTarget()
    {
        float stepSize = RotateSpeed * Time.deltaTime;

        Vector3 targetDir = target.pos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void moveForward()
    {
        float stepSize = Time.deltaTime * MoveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if (distanceToTarget < stepSize)
        {
            return;
        }

        //Take a step forward
        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir * stepSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        //switch to next target
        //float stepSize = 0;
        //Vector3 moveDir = Vector3.forward;
        //transform.Translate(moveDir * stepSize);

        isIdle = !isIdle;
        animator.SetBool("isIdle", isIdle);
       

        target = pathManager.GetNextTarget();
        Debug.Log("1");

    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            //toggle if any key is pressed
            isWalking = !isWalking;
            animator.SetBool("isWalking", isWalking);
        }


        if (isWalking)
        {
            rotateTowardsTarget();
            moveForward();
        }

    }



}