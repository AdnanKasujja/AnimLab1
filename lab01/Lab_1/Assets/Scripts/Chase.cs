using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public Transform player;
    Animator anim;
    bool isWalking;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = player.position - this.transform.position; //Calculate distance between enemy and player
        direction.y = 0;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(player.position, this.transform.position) < 15 && angle < 30) //Viewing cone, enemy will only detect player if at a certain distance and angle
        {     
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("isWalking", false);    
            {
                this.transform.Translate(0, 0, 0.01f);
                anim.SetBool("Sprint", true);
            }
        }
        else if (Vector3.Distance(player.position, this.transform.position) > 5)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
        }
        else
        {
            //anim.SetBool("IsIdle", true);
            anim.SetBool("isWalking", true);
        }


	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube")
        {
            isWalking = false;
            anim.SetTrigger("Attacking");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Cube")
        {
            isWalking = true;
            anim.SetBool("isWalking", isWalking);
        }
    }
}
