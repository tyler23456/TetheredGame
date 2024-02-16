using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    public class Character : Runner, ICharacter
    {
        bool isInitialized = false;
        IFactory factory;

        [SerializeField] protected Collider userCollider;
        [SerializeField] protected Movement movement;
        [SerializeField] protected Orientation orientation;
        [SerializeField] protected new Animation animation;
        [SerializeField] protected Stats stats;
        [SerializeField] protected Equipped equipped;
        [SerializeField] protected StepSFX stepSFX;
        [SerializeField] protected SoundFX soundFX;

        public Collider getCollider => userCollider;
        public Vector3 getCenter => userCollider.bounds.center;
        public Vector3 getPosition => transform.position;
        public Vector3 getForward => transform.forward;

        public IMovement getMovement => movement;
        public IOrientation getOrientation => orientation;
        public IEquipped getEquipped => equipped;
        public IAnimation getAnimation => animation;
        public IStats getStats => stats;

        public bool isVisible { get; private set; }


        protected new void Start()
        {
            if (!isInitialized)
            {
                isInitialized = true;
                factory = GameObject.Find("DontDestroyOnLoad").GetComponent<IFactory>();
            }

            
            //temporary
            //if (!IsOwner)
            //return;
            //temporary

            stats.Initialize();
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

        protected void OnBecameVisible()
        {
            isVisible = true;
        }

        protected void OnBecameInvisible()
        {
            isVisible = false;
        }

        public void SpawnEffectByName(string name)
        {
            throw new System.NotImplementedException();
        }

        void StepSFX(AnimationEvent animEvent)
        {
            if (animEvent.animatorClipInfo.weight < 0.5f)
                return;

            soundFX.Play(factory.StepSFX[stepSFX.GetStepSFXType() + "Walk"], 0.7f, 1.1f, 0.1f, 0.2f);
        }
    }
}