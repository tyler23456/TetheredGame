using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace GT.DontDestroyOnLoad
{
    public class Target : NetworkBehaviour, ITarget
    {
        ICharacter character;

        public bool hasTarget => character != null;
        public Vector3 getPosition => character.getPosition;
        public Vector3 getForward => character.getForward;
        public ICharacter getCharacter => character;
        public Vector3 getCenter => character.getCollider.bounds.center;
        public IStats getStats => character.getStats;

        public void Set(ICharacter character)
        {
            this.character = character;
        }
    }
}