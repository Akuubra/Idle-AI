using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceController {

    private static int bits;

    public static void IncrementBits()
    {
        bits++;
    }

    public static void ReduceBits(int _amount)
    {
        bits -= _amount;
    }
    public static int GetBits()
    {
        return bits;
    }
}
