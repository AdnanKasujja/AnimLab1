using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynaCam : MonoBehaviour
{
    private void Update()
    {
        
        Vector3 inputDirection = new Vector3(0, 0, 0);
        //Moving the camera
        if (Input.GetMouseButton(0)) inputDirection.z = +1f;

        Vector3 moveDirection = transform.forward * inputDirection.z + transform.right * inputDirection.x;

        
        float movementSpeed = 10f;
        transform.position += moveDirection * movementSpeed * Time.deltaTime;

        //Rotating the camera
        float rotationDirection = 0f;
        if (Input.GetMouseButton(0)) rotationDirection = -3f;

        float rotationSpeed = 100f;
        transform.eulerAngles += new Vector3(0, rotationDirection * rotationSpeed *Time.deltaTime, 0);
        

    }

}
