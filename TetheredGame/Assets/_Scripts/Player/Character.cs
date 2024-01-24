using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Player
{
    public class Character : Runner
    {
        [SerializeField] Controls controls;
        [SerializeField] Position position;
        [SerializeField] Rotation rotation;

        protected new void Awake()
        {
            if (!IsOwner)
                return;

            base.Awake();
        }

        protected new void Start()
        {
            if (!IsOwner)
                return;

            base.Start();
        }

        protected new void Update()
        {
            if (!IsOwner)
                return;

            base.Update();

            controls.Update();
            position.Update();
            rotation.Update();
        }
    }
}