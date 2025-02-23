using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTagsCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            print("Has perdido");
        }
        else if(other.CompareTag("Finish"))
        {
            print("Has ganado");
        }
    }
}
