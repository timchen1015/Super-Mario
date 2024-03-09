using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoombaMovement : MonoBehaviour
{
    private Animator anim;
    NavMeshAgent agent;
    GameObject target;

    [SerializeField] private float stoppingDistance;
    [SerializeField] private float stoppingDistance2;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Movement();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Mario" && (collision.transform.position.y) > transform.position.y + 0.2)
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            Destroy(transform.gameObject, 0.2f);
        }
    }

    private void chase()
    {
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
    }

    private void stop()
    {
        anim.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);
    }

    private void GoToTarget()
    {
        agent.SetDestination(target.transform.position);
        chase();
    }
    private void Movement()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < stoppingDistance)
        {
            stop();
        }
        else if (dist > stoppingDistance2)
        {
            stop();
        }
        else
        {
            GoToTarget();
        }
    }
}
