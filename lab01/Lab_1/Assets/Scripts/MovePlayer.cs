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
    private float animTransition = 0.15f;

    public GameObject playerModel;

    int jumpAnim;
    int coverAnim;


    


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        anim.SetFloat("XMovement", 1f);
        anim.SetFloat("ZMovement", 1f);
        jumpAnim = Animator.StringToHash("Rifle Jump In Place");
        coverAnim = Animator.StringToHash("Rifle Stand To Kneel");
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
                anim.CrossFade(jumpAnim, animTransition);
            }
        }

        movementDirection.y = movementDirection.y + (Physics.gravity.y * Gravity * Time.deltaTime);
        controller.Move(movementDirection * Time.deltaTime);

        anim.SetFloat("XMovement", movementDirection.x);
        anim.SetFloat("ZMovement", movementDirection.z);

        if (Input.GetMouseButton(1))
        {
            anim.SetBool("isReloading", true);
        }
        else
        {
            anim.SetBool("isReloading", false);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube")
        {
            anim.SetBool("inCover", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Cube")
        {
            anim.SetBool("inCover", false);
        }
    }

}
