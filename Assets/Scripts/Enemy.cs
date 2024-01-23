using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 50;
    private Rigidbody enemyRb;
    private Player player;
    private NavMeshAgent navMeshAgent;
    private Animations enemyAnim;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //enemyRb = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
        enemyAnim = GetComponent<Animations>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //enemyRb.AddForce(lookDirection * speed);
        navMeshAgent.SetDestination(player.transform.position);
        if(navMeshAgent.isStopped != true)
        {
            enemyAnim.WalkAnim();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            navMeshAgent.isStopped = true;
            enemyAnim.DieAnimation();
            Invoke("DestroyEnemy", 2f);
            Destroy(other.gameObject);
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
