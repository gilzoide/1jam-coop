using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction : MonoBehaviour
{
    public enum Kind {
        Enemy,
        Player,
    }

    public Kind faction;

    public bool HostileTo(Kind other)
    {
        return faction != other;
    }
    public bool HostileTo(Faction other)
    {
        return faction != other.faction;
    }
}
