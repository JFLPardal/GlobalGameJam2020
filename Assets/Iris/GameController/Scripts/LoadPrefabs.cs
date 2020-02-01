using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class LoadPrefabs
{
    public static Dictionary<string, GameObject> bodyParts = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> animalParts = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> combinedParts = new Dictionary<string, GameObject>();

    public static GameObject claw;

    private static string bodyPartsPath = "Assets/Iris/BodyParts/Prefabs/";
    private static string animalPartsPath = "Assets/Iris/AnimalParts/Prefabs/";
    private static string combinedPartsPath = "Assets/Iris/CombinedParts/Prefabs/";

    public static void Start()
    {
        LoadBodyParts();
        LoadAnimalParts();
        LoadCombinedParts();
        LoadClaw();
    }

    public static GameObject GetCombinedPart(string fullName)
    {
        return combinedParts[fullName];
    }

    public static GameObject GetBodyPart(string fullName)
    {
        return bodyParts[fullName];
    }

    public static GameObject GetAnimalPart(string fullName)
    {
        return animalParts[fullName];
    }

    public static GameObject GetClawPrefab()
    {
        return claw;
    }

    private static void LoadClaw()
    {
        claw = AssetDatabase.LoadAssetAtPath("Assets/Iris/Claw/Prefabs/claw.prefab", typeof(GameObject)) as GameObject;
    }

    private static void LoadBodyParts()
    {
        bodyParts.Add("Barms", AssetDatabase.LoadAssetAtPath(bodyPartsPath + "Barms.prefab", typeof(GameObject)) as GameObject);
        bodyParts.Add("Blegs", AssetDatabase.LoadAssetAtPath(bodyPartsPath + "Blegs.prefab", typeof(GameObject)) as GameObject);
        bodyParts.Add("Bhead", AssetDatabase.LoadAssetAtPath(bodyPartsPath + "Bhead.prefab", typeof(GameObject)) as GameObject);
    }

    private static void LoadAnimalParts()
    {
        string[] animalPartTypeNames = System.Enum.GetNames(typeof(PartType));
        string[] animalSpeciesNames = System.Enum.GetNames(typeof(Species));
        foreach( var part in animalPartTypeNames)
        {
            string cleanBodyPart = "A" + part.ToLower() + "_";
            foreach(var species in animalSpeciesNames)
            {
                string fullName = cleanBodyPart + species.ToLower();
                animalParts.Add(fullName, 
                    AssetDatabase.LoadAssetAtPath(animalPartsPath + fullName + ".prefab", typeof(GameObject)) as GameObject);
            }
        }
    }

    private static void LoadCombinedParts()
    {
        string[] partTypeNames = System.Enum.GetNames(typeof(PartType));
        string[] animalSpeciesNames = System.Enum.GetNames(typeof(Species));

        foreach(var species in animalSpeciesNames)
        {
            var cleanSpecies = species.ToLower();
            if (cleanSpecies != "unknown")
            {
                for (int i = 0; i < partTypeNames.Length - 1; i++)
                {
                    string cleanBodyPart = "B" + partTypeNames[i].ToLower() + "_";
                    string cleanAnimalPart = "A" + partTypeNames[i].ToLower() + "_";
                    string fullName = cleanBodyPart + cleanAnimalPart + cleanSpecies;
                    combinedParts.Add(fullName, 
                        AssetDatabase.LoadAssetAtPath(combinedPartsPath + fullName + ".prefab", typeof(GameObject)) as GameObject);
                }
            }
        }
    }

}
