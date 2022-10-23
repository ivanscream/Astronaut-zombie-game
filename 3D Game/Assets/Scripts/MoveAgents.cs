using UnityEngine;
using UnityEngine.AI;

public class MoveAgents : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] goPoints;
    private Transform currentPlace;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        SetNewPath();
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("GoPoint")) {
            SetNewPath();
        }
    }
    public void SetNewPath() {
        Transform moveTo = goPoints[Random.Range(0, goPoints.Length)];
        if(currentPlace != null && currentPlace.position == moveTo.position) {
            SetNewPath();
            return;
        }
        currentPlace = moveTo;
        if(agent.enabled)
            agent.SetDestination(moveTo.position);
    }
}
