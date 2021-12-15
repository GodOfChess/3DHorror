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
        Debug.Log(1);
        yield return new WaitForSeconds(10f);
        Debug.Log(2);
        isHunt = false;
        //gameObject.SetActive(false);
        Debug.Log(3);
        yield return new WaitForSeconds(10f);
        Debug.Log(4);
        //gameObject.SetActive(true);
        isHunt = true;
        Debug.Log(5);
        StartCoroutine(StartHunt());
    }


}
