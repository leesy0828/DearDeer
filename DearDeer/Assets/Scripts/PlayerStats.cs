using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    SANITY,
    SELF_DESTRUCTION,
    AGGRESSIVE,
    OBEYING
}

public class PlayerStats : MonoBehaviour
{
    public int Sanity { get; private set; }
    public int selfDestruction { get; private set; }
    public int Aggressive { get; private set; }
    public int Obeying { get; private set; }

    public void ChangeStats(StatType statType, int amount)
    {
        switch (statType)
        {
            case StatType.SANITY:
                Sanity += amount;
                break;
            case StatType.SELF_DESTRUCTION:
                selfDestruction += amount;
                break;
            case StatType.AGGRESSIVE:
                Aggressive += amount;
                break;
            case StatType.OBEYING:
                Obeying += amount;
                break;
        }
    }
}
