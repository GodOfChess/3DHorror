using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform playerPos;
    private CapsuleCollider ghostCollider;
    public Transform player;
    public SkinnedMeshRenderer mesh;
    public AudioSource main, boss;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = 0;
        ghostCollider = GetComponent<CapsuleCollider>();
        ghostCollider.enabled = false;
    }

    private void Update()
    {
        playerPos = player.GetComponent<Transform>();
        navMeshAgent.SetDestination(playerPos.position);
    }

    public IEnumerator StartHunt()
    {
        yield return new WaitForSeconds(60f);
        mesh.enabled = true;
        navMeshAgent.speed = 3.5f;
        ghostCollider.enabled = true;
        main.Stop();
        boss.Play();
        yield return new WaitForSeconds(30f);
        mesh.enabled = false;
        navMeshAgent.speed = 0;
        ghostCollider.enabled = false;
        boss.Stop();
        main.Play();
        StartCoroutine(StartHunt());
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
