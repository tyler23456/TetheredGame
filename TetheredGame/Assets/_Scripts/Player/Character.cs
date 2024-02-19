using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    public class Character : Runner, ICharacter
    {
        const float ANIMATOR_SPEED_MULTIPLIER = 1f;

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
        [SerializeField] protected CameraVisibility cameraVisibility;
 
        public Collider getCollider => userCollider;
        public Vector3 getCenter => userCollider.bounds.center;
        public Vector3 getPosition => transform.position;
        public Vector3 getForward => transform.forward;

        public IMovement getMovement => movement;
        public IOrientation getOrientation => orientation;
        public IEquipped getEquipped => equipped;
        public IAnimation getAnimation => animation;
        public IStats getStats => stats;

        public bool isVisible => cameraVisibility.isVisible;


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

            //Animator animator = GetComponent<Animator>();
            //stats.AddOnValueChangedTo("Thrill", (value) => animator.speed = 1 + (value / 100f * ANIMATOR_SPEED_MULTIPLIER));
        }

        protected new void Update()
        {
            //temporary
            //if (!IsOwner)
                //return;
            //temporary

            base.Update();

            if (Input.GetKeyDown(KeyCode.E))
            {
                stats.OffsetAttribute("Thrill", 20);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                stats.OffsetAttribute("Sanity", -20);
            }

            movement.Update();
            orientation.Update();
            stats.Update();
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