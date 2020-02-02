using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadPrefabs;
using static OrderCompletion;

public class GameController : MonoBehaviour
{
    private float clawGenerationInterval = 10;

    void Start()
    {
        LoadPrefabs.Start();
        InvokeRepeating("CreateClaw", 0.01f, clawGenerationInterval);
    }

    private void CreateClaw()
    {
        Instantiate(GetClawPrefab(), new Vector3(-5, 5, 8), new Quaternion(0, 0, 0, 0));
    }
}
