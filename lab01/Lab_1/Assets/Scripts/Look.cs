﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {

    public Transform target;
    public Transform aimTowards;
    public Transform pivot;

    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;
    public float maxViewAngle;
    public float minViewAngle;
    public float distanceToAim;

    public bool invertY;

	// Use this for initialization
	void Start () {
        if(useOffsetValues)
        { 
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        pivot.transform.parent = null;
        //Cursor.lockState = CursorLockMode.Locked; //This is what allows the mouse to disappear, having issues with it
    }

    // Update is called once per frame
    void Update()
    {
        aimTowards.position = pivot.position + pivot.forward * distanceToAim;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20.0F, Color.red);
    }



	void LateUpdate () {

        

        pivot.transform.position = target.transform.position;

        //Get the x position of the mouse and rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        //Get Y position of mouse and rotate pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //pivot.Rotate(vertical, 0, 0);
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        //Limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360 + minViewAngle, 0, 0);
        }

        //Move the camera based on the current rotation of the target and original offset
        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);



        //transform.position = target.position - offset;

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        }

        transform.LookAt(target);
	}
}
