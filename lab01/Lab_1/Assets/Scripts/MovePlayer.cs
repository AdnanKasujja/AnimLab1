using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float movementSpeed;
    public float jumpingForce;
    public CharacterController controller;

    private Vector3 movementDirection;
    public float Gravity;

    public Animator anim;
    //public Transform pivot;
    public float rotationSpeed;

    public GameObject playerModel;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float ystore = movementDirection.y;
        movementDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        movementDirection = movementDirection.normalized * movementSpeed;
        movementDirection.y = ystore;

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                movementDirection.y = jumpingForce;
            }
        }

        movementDirection.y = movementDirection.y + (Physics.gravity.y * Gravity * Time.deltaTime);
        controller.Move(movementDirection * Time.deltaTime);
    }
}
