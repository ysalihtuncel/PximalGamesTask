using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript
{
    public static bool RandomBoolean(int range = 4) {
        return Random.Range(0,range) == 1;
    }
}
