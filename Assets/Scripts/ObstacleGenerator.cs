using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle; 
    public int obstaclesNum = 10; 

    private BoxCollider area; 

    void Start()
    {
        area = GetComponent<BoxCollider>();

        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        for(int i = 0; i < obstaclesNum; i++)
        {
            Vector3 randomPosition = GetRandomPositionInArea();
            Instantiate(obstacle, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionInArea()
    {
        Vector3 center = area.bounds.center;
        Vector3 size = area.bounds.size;
        
        float x = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float y = center.y;
        float z = Random.Range(center.z - size.z / 2, center.z + size.z / 2);
        
        return new Vector3(x, y, z);
    }
}
