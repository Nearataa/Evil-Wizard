using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
  
    public GameObject objectToSpawn; // The object prefab to spawn
    public BoxCollider2D spawnArea;  // The area within which to spawn objects

    // The number of objects to spawn
    public int numberOfObjects = 10;

    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
        
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found. Please ensure you have a Camera tagged as MainCamera.");
            return;
        }
        Invoke("SpawnObjects", 0);
    }
    

 
  

    private void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = GetRandomPosition();
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition()
    {
        Bounds bounds = spawnArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector3(x, y, 0); // Assuming 2D, so z=0
    }
    
}
