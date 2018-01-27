using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManagement : MonoBehaviour
{
    public GameObject sheep;
    public float minNumberOfSheeps;
    public float maxNumberOfSheeps;
    public float yRandomDisplacement, xRandomDisplacement;

    private float layerWidth, layerHeight;
    private int numberOfSheeps;

    private void Start()
    {
        Populate();
    }

    internal void Populate()
    {
        layerWidth = GetComponent<BoxCollider2D>().size.x/2;
        layerHeight = GetComponent<BoxCollider2D>().size.y/2;

        numberOfSheeps = (int)UnityEngine.Random.Range(minNumberOfSheeps, maxNumberOfSheeps);

        for (int i = 0; i < numberOfSheeps; i++)
        {
            var spawnPos = new Vector3(randomDisplacement(layerWidth),
                randomDisplacement(layerHeight),
                0f);
            Instantiate(sheep, spawnPos, Quaternion.identity, transform);
        }
    }

    float randomDisplacement(float width)
    {
        return UnityEngine.Random.Range(-1f, 1f) * width;
    }
}
