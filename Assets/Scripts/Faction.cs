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
}
