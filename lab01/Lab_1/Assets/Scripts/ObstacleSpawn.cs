using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public float playerRange;
    public GameObject obstacle;
    public GameObject spawn;
    public GameObject spawn2;
    public GameObject spawn3;
    private GameObject player;
    private bool firingObstacle = false;
    private float obstacleSpawnTime;
    private float coolDownTime = 0.5f;

    void Start() 
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (isPlayerInRange())
        {
            transform.LookAt(player.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20.0F, Color.red);
                if (hit.transform.gameObject.tag == "Player")
                {
                    if (firingObstacle == false)
                    {
                        firingObstacle = true;
                        obstacleSpawnTime = Time.time;
                        GameObject.Instantiate(obstacle, spawn.transform.position, transform.rotation);
                    }
                }
            }
        }
        if (firingObstacle && obstacleSpawnTime + coolDownTime <= Time.time)
            firingObstacle = false;
    }

    bool isPlayerInRange()
    {
        return (Vector3.Distance(player.transform.position, transform.position) <= playerRange);
    }
}
