using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynaCam : MonoBehaviour
{
    private void Update()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);

        if (Input.GetMouseButton(0)) inputDir.z = +1f;

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

        float moveSpeed = 10f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

    }
}
