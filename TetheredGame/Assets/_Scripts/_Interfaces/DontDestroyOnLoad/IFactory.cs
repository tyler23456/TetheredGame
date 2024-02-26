using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
    Dictionary<string, List<AudioClip>> StepSFX { get; }

    GameObject getPlayer { get; }
    GameObject getMainCamera { get; }
    Dictionary<string, GameObject> canvas { get; }
    Transform getScreenDisplay { get; }
    AudioSource getAudioSource { get; }
    
    Dictionary<string, AudioClip> userAudio { get; }
    Dictionary<string, GameObject> effects { get; }
    Dictionary<string, GameObject> notes { get; }
    Dictionary<string, GameObject> cursedItems { get; }

    void MovePlayerTo(Vector3 position, Vector3 forward);
    RaycastHit RaycastFromCamera(float distance);

    GameObject GetWeightedRandomEffect();
}
