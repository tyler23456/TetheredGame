using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    public class Character : Runner, ICharacter
    {
        [SerializeField] protected Movement movement;
        [SerializeField] protected Orientation orientation;
        [SerializeField] protected new Animation animation;
        [SerializeField] protected Stats stats;
        [SerializeField] protected Equipped equipped;


        public Vector3 getPosition => transform.position;
        public Vector3 getForward => transform.forward;

        public IMovement getMovement => movement;
        public IOrientation getOrientation => orientation;
        public IEquipped getEquipped => equipped;
        public IAnimation getAnimation => animation;
        public IStats getStats => stats;


        protected new void Start()
        {
            



            //temporary
            //if (!IsOwner)
                //return;
            //temporary

            base.Start();
        }

        protected new void Update()
        {
            //temporary
            //if (!IsOwner)
                //return;
            //temporary

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