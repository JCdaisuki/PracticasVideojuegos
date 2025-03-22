using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        print(other.gameObject.layer);
        if(other.gameObject.layer == 8) //Layer de criaturas
        {
            other.gameObject.GetComponent<EnemyController>().Die();
            FindAnyObjectByType<FirstPersonUI>().AddPoint();
        }
    }
}
