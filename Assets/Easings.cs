using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Easings
{
    public static float EaseInQuad(float x)
    {
        return x * x;
    }

    public static float EaseOutQuad(float x)
    {
        return x / x;
    }

    public static float EaseInQuint(float x)
    {
        return x * x * x * x * x;
    }
}
