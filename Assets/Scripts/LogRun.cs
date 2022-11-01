using UnityEngine;
using UnityEngine.AI;

public class LogRun : MonoBehaviour
{
    public NavMeshAgent enemy;
    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        enemy.SetDestination(player.transform.position);
    }
}
