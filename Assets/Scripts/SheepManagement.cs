using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManagement : MonoBehaviour
{
    public GameObject sheep;
    public List<GameObject> listaPecore = new List<GameObject>();
    public float minNumberOfSheeps;
    public float maxNumberOfSheeps;
    public float yRandomDisplacement, xRandomDisplacement;
    public int screenSizeX, screenSizeY;
    private float layerWidth, layerHeight;
    private int numberOfSheeps;


    private void Start()
    {
        StartCoroutine(Populate());
    }

    IEnumerator Populate()
    {
        layerWidth = screenSizeX/2;
        layerHeight = screenSizeY/2;

        numberOfSheeps = (int)UnityEngine.Random.Range(minNumberOfSheeps, maxNumberOfSheeps);

        for (int i = 0; i < numberOfSheeps; i++)
        {
            Vector3 spawnPos = new Vector3(randomDisplacement(layerWidth),
                randomDisplacement(layerHeight),
                0f);
            GameObject pecora=Instantiate(sheep, spawnPos, Quaternion.identity, transform);
            listaPecore.Add(pecora);
        }
        yield return null;

    }

    float randomDisplacement(float width)
    {
       float f =UnityEngine.Random.Range(-1f, 1f) * width;
       int i = (int)f;
        float c = i;
        return c;

    }
}
