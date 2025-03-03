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
        transform.LookAt(target.transform);
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

        GetPressed(pressed, 0.3f);
    }

    public void Spawn()
    {
        GameObject effectInstance = Instantiate(pofEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 3f);

        foreach(Collider collider in colliders)
        {
            collider.enabled = true;
        }

        foreach(SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
        {
            skinnedMeshRenderer.enabled = true;
        }

        navMeshAgent.speed = navMeshSpeed;
        transform.localScale = normal;
    }
    
    private IEnumerator GetPressed(Vector3 targetScale, float duration)
    {
        Vector3 initialScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;

        foreach(SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
        {
            skinnedMeshRenderer.enabled = false;
        }
        
        isDead = true;
        navMeshAgent.speed = 0;
    }
}
