using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    public NavMeshAgent navMeshAgent;
    public Collider[] colliders;
    public SkinnedMeshRenderer[] skinnedMeshRenderers;

    [Header("Config.")]
    public GameObject target;
    public float navMeshSpeed;

    [Header("Death")]
    public bool isDead = false;
    public float sizeReduction = 3f;
    private Coroutine scaleCoroutine;
    private Vector3 normal;
    private Vector3 pressed;
    public GameObject pofEffect;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();

        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.layer == LayerMask.NameToLayer("Player"))
            {
                target = obj;
                break;
            }
        }

        navMeshSpeed = navMeshAgent.speed;

        colliders = GetComponentsInChildren<Collider>();
        skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        
        normal = transform.localScale;
        pressed = new Vector3(transform.localScale.x * (sizeReduction / 2), transform.localScale.y / sizeReduction, transform.localScale.z * (sizeReduction / 2));
    }

    private void Update()
    {
        if(isDead)
        {
            return;
        }

        SetNavDestination(target.transform.position);

        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0; 
        if (direction != Vector3.zero) 
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void SetNavDestination(Vector3 destination)
    {
        if(navMeshAgent.enabled)
        {
            navMeshAgent.SetDestination(destination);
        }
    }

    public void Die()
    {
        foreach(Collider collider in colliders)
        {
            collider.enabled = false;
        }

        GameObject effectInstance = Instantiate(pofEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 1f);
        Destroy(gameObject);
    }
}
