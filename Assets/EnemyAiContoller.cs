using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiContoller : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    private bool followTarget = true;

    private Rigidbody rigidBody;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(followTarget){
            float distance = Vector3.Distance(target.position, transform.position);
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance){
                followTarget = false;
                FaceTarget();
                agent.isStopped = true;
                agent.enabled = false;
                rigidBody.isKinematic = false;
            }
        }else{
            //* 1000 * Time.deltaTime
            rigidBody.AddRelativeForce (Vector3.forward , ForceMode.Impulse);
        }
    }

    private void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation= Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
