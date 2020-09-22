using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour
{
    public AnchoredMotor motor;
    public GameObject dotPrefab;
    public GameObject StarDotPrefab;
    public GameData GameData;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        RemoveDuplicates();
        var angle = Random.Range(GameData.MinSpawnAngle, GameData.MaxSpawnAngle);
        var go = Instantiate(SelectRandomDot(), motor.transform.position, Quaternion.identity, transform);
        go.transform.RotateAround(transform.position, Vector3.forward, -angle * (int)motor.Direction);
    }

    GameObject SelectRandomDot()
    {
        //Random.value returns a value between 0 and 1
        if(Random.value < 0.2)
        {
            return StarDotPrefab;
        }
        else
        {
            return dotPrefab;
        }
    }

    void RemoveDuplicates()
    {
        var dots = GameObject.FindGameObjectsWithTag("Dot");
        foreach(GameObject dot in dots)
        {
            GameObject.Destroy(dot);
        }
    }
}
