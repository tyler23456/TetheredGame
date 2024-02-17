using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGlobalAttributes
{
    public int round { get; }
    public void IncrementRound();
}
