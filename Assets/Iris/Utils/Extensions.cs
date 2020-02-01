using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static string BodyPartTypeMapper(BodyPartType type)
    {
        switch (type)
        {
            case BodyPartType.ARMS:
                return "Barms_";
            case BodyPartType.HEAD:
                return "Bhead_";
            case BodyPartType.LEGS:
                return "Blegs_";
        }

        return "";
    }

    public static string AnimalPartTypeMapper(BodyPartType type)
    {
        switch (type)
        {
            case BodyPartType.ARMS:
                return "Aarms_";
            case BodyPartType.HEAD:
                return "Ahead_";
            case BodyPartType.LEGS:
                return "Alegs_";
        }

        return "";
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
        }
        return "";
    }
}
