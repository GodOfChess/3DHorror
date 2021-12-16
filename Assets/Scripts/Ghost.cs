using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform startPoint, playerPos;
    public Transform player;
    private bool isHunt = false;
    public SkinnedMeshRenderer mesh;


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

    //public IEnumerator StartHunt()
    //{
    //    Debug.Log(1);
    //    yield return new WaitForSeconds(11f);
    //    Debug.Log(2);
    //    isHunt = false;
    //    //gameObject.SetActive(false);
    //    Debug.Log(3);
    //    yield return new WaitForSeconds(10f);
    //    Debug.Log(4);
    //    //gameObject.SetActive(true);
    //    isHunt = true;
    //    Debug.Log(5);
    //    StartCoroutine(StartHunt());
    //}

    public IEnumerator StartHunt()
    {
        yield return new WaitForSeconds(10f);
        mesh.enabled = true;
        isHunt = true;
        yield return new WaitForSeconds(10f);
        mesh.enabled = false;
        isHunt = false;
        StartCoroutine(StartHunt());
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }

}
