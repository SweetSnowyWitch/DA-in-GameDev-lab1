using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject spawnCube;
    public int cubeCount = 0;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (counter < cubeCount)
        {
            Instantiate(spawnCube);
            counter++;
        }
    }
}