using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent agent;
    public static float damage = 5f;
    private Coroutine dmg;
    private Animator anim;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("EnemyDetect") && agent.enabled && agent != null && !PlayerHealth.death) {
            if(agent.enabled) {
                agent.SetDestination(other.transform.parent.gameObject.transform.position);
                agent.speed = 3f;
            }
        }

        if(other.CompareTag("Attack") && !PlayerHealth.death){
            if (dmg == null)
                dmg = StartCoroutine(SetDamage(other));
                anim.SetBool("isAttacking", true);
        } 

    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("EnemyDetect") && agent.enabled) {
            GetComponent<MoveAgents>().SetNewPath();
            agent.speed = 1f;
        }

        if (other.CompareTag("Attack") && dmg != null) {
            StopCoroutine(dmg);
            dmg = null;
            anim.SetBool("isAttacking", false);
        }
    }

    IEnumerator SetDamage(Collider other) {
        while (true) {
            if(agent.enabled && !PlayerHealth.death)
                other.transform.parent.GetComponent<PlayerHealth>().TakeDamage(damage);
            yield return new WaitForSeconds(2f);
            
        }
    }

    private void Update() {
        if(PlayerHealth.death)
            StopAllCoroutines();
    }
}

