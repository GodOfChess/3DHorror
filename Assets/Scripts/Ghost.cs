using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform startPoint, playerPos;
    public Transform player;
    private bool isHunt = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        startPoint = GetComponent<Transform>();
    }

    private void Update()
    {
        if (isHunt)
        {
            playerPos = player.GetComponent<Transform>();
            navMeshAgent.SetDestination(playerPos.position);
        }
    }

    public IEnumerator StartHunt()
    {
        isHunt = true;

        yield return new WaitForSeconds(10f);
        isHunt = false;
        gameObject.SetActive(false);

        yield return new WaitForSeconds(10f);
        gameObject.SetActive(true);
        StartCoroutine(StartHunt());
    }


}
