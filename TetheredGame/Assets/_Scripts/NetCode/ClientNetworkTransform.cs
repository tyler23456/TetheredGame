using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode.Components;

namespace TG.Network
{
    [DisallowMultipleComponent]
    public class ClientNetworkTransform : NetworkTransform
    {
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}