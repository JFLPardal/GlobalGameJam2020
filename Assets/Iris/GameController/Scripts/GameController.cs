using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadPrefabs;
using static OrderCompletion;

public class GameController : MonoBehaviour
{
    [SerializeField] Vector3 initialPositionToSpawn = new Vector3(10, 6, 30);
    private float clawGenerationInterval = 10;

    void Start()
    {
        LoadPrefabs.Start();
        InvokeRepeating("CreateClaw", 0.01f, clawGenerationInterval);
    }

    private void CreateClaw()
    {
        print("create");
        Instantiate(GetClawPrefab(), initialPositionToSpawn, new Quaternion(0, 0, 0, 0));
    }
}
