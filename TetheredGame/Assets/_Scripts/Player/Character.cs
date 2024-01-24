using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Player
{
    public class Character : Runner, ICharacter
    {
        [SerializeField] protected Movement movement;
        [SerializeField] protected Orientation orientation;


        public Vector3 getPosition => transform.position;
        public Vector3 getForward => transform.forward;

        public IMovement getMovement => movement;
        public IOrientation getOrientation => orientation;
        public IInventory getKeyItems => throw new System.NotImplementedException();
        public IInventory getEquipment => throw new System.NotImplementedException();
        public IAnimations getAnimations => throw new System.NotImplementedException();


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

            movement.Update();
            orientation.Update();
        }

        public void SpawnEffectByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}