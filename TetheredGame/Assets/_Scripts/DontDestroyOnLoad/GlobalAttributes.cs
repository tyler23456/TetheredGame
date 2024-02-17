using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAttributes : MonoBehaviour
{
    const int MAX_ROUND = 10;

    public int round { get; private set; } = 1;

    public void IncrementRound()
    {
        round++;
    }

    public void Update()
    {
        if (round < MAX_ROUND)
            return;

        //put game winning logic here
    }
}
