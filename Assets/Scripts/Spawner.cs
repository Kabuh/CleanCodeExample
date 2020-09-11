using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject leftEdge;
    [SerializeField]
    private GameObject rightEdge;

    float leftEdgeX;
    float rightEdgeX;
    
    

    private void Awake()
    {
        leftEdgeX = leftEdge.transform.position.x;
        rightEdgeX = rightEdge.transform.position.x;
        WaveManager.currentSpawner = this;
    }

    public void Spawn(GameObject enemy) {
        float randomX = Random.Range(0, 100);
        float Xdelta = (rightEdgeX - leftEdgeX) / 100 * randomX;
        Vector3 spawnPosition = new Vector3(leftEdge.transform.position.x + Xdelta, this.transform.position.y, 0);
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
