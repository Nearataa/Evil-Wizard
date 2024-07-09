using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    public GameObject objectToInstantiate;
    public int numberOfObjects = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objectToInstantiate, Vector3.zero, Quaternion.identity);;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
