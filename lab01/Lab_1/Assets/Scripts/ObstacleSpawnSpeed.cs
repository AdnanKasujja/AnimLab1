using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnSpeed : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
