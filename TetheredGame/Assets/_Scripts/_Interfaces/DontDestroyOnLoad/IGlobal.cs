using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGlobal
{
    ICharacter target { get; }
    ICharacter enemy { get; }

    Camera getMainCamera { get; }
    Transform getNoteDisplay { get; }
    Transform getSceneEffects { get; }

    public int round { get; }
    public void IncrementRound();
    public void SetTarget(ICharacter target);
}
