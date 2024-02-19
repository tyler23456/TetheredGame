using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TG.UserPlayer
{
    public class UserInput : MonoBehaviour
    {
        [SerializeField] Camera userCamera;
        [SerializeField] Animator flashlightAnimator;
        
        PlayerInputActions playerInputActions;
        ICharacter character;
        IFactory factory;

        IActivator activator;

        public void Awake()
        {
            playerInputActions = new PlayerInputActions();
            playerInputActions.Player.Enable();

            character = GetComponent<ICharacter>();
            factory = GameObject.Find("/DontDestroyOnLoad").GetComponent<IFactory>();
        }

        public void Update()
        {
            character.getOrientation.Forward(userCamera.transform.forward);
            character.getAnimation.SetSpeed(0f);
            character.getAnimation.SetVelocity(Vector3.zero);
            if (playerInputActions.Player.Movement.IsPressed())
            {
                Movement(playerInputActions.Player.Movement.ReadValue<Vector2>());
                
                if (Input.GetKey(KeyCode.LeftShift))
                    character.getAnimation.SetSpeed(2f);
                else
                    character.getAnimation.SetSpeed(1f);
            }

            if (playerInputActions.Player.ToggleFlashlight.WasPerformedThisFrame())
                flashlightAnimator.SetTrigger("Toggle");

            if (playerInputActions.Player.Interact.WasPerformedThisFrame())
                CheckForInteraction();
        }

        public void Movement(Vector2 inputVector)
        {       
            Vector3 inputVector3D = new Vector3(inputVector.x, 0f, inputVector.y);
            float speedMultiplier = (character.getStats.GetAttribute("Thrill") / 100f) + 1;
            character.getAnimation.AddVelocity(inputVector3D * speedMultiplier);
            
        }

        public void CheckForInteraction()
        {
            bool hashit = Physics.Raycast(new Ray(userCamera.transform.position, userCamera.transform.forward), out RaycastHit hitInfo, 5f);

            if (!hashit || hitInfo.transform.tag == "IgnorePlayer")
                return;

            activator = hitInfo.transform.GetComponent<IActivator>();

            if (activator == null)
                return;

            activator.userPosition = transform.position;
            activator.Activate();
        }
    }
}