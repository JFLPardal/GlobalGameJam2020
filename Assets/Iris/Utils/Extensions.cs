using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static string BodyPartTypeMapper(PartType type)
    {
        switch (type)
        {
            case PartType.ARMS:
                return "Barms_";
            case PartType.HEAD:
                return "Bhead_";
            case PartType.LEGS:
                return "Blegs_";
            default:
                return string.Empty;
        }
    }

    public static string AnimalPartTypeMapper(PartType type)
    {
        switch (type)
        {
            case PartType.ARMS:
                return "Aarms_";
            case PartType.HEAD:
                return "Ahead_";
            case PartType.LEGS:
                return "Alegs_";
            default:
                return string.Empty;
        }
    }

    public static string AnimalSpeciesMapper(Species species)
    {
        switch (species)
        {
            case Species.REDPANDA:
                return "redpanda";
            case Species.FISH:
                return "fish";
            case Species.DUCK:
                return "duck";
            case Species.CROCODILE:
                return "crocodile";
            default:
                return string.Empty;
        }
    }

    public static Species GetRandomSpecies()
    {
        return (Species) UnityEngine.Random.Range(0, Enum.GetValues(typeof(Species)).Length - 1);
    }
    public static PartType GetRandomPart()
    {
        return (PartType) UnityEngine.Random.Range(0, Enum.GetValues(typeof(PartType)).Length - 1);
    }

    public static bool ContainsPair(this List<PartSpeciesStruct> list, PartSpeciesStruct newPair)
    {
        foreach (var pair in list)
        {
            if (pair.species == newPair.species && pair.type == newPair.type)
            {
                return true;
            }
        }
        return false;
    }

}
