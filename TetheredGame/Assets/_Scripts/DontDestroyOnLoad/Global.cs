using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour, IGlobal
{
    const int MAX_ROUND = 10;

    public int round { get; private set; } = 1;
    public ICharacter target { get; private set; }
    public ICharacter enemy { get; private set; }

    public void Update()
    {
        if (round < MAX_ROUND)
            return;

        //put game winning logic here
    }

    public void IncrementRound()
    {
        round++;
    }

    public void SetTarget(ICharacter target)
    {
        this.target = target;
    }
}
