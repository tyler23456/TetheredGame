using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TG.UserPlayer
{
    public class UserInput : MonoBehaviour
    {
        [SerializeField] Camera userCamera;
        [SerializeField] Animator flashlightAnimator;
        [SerializeField] Transform screenCanvasDisplay;

        float dropDuration = 1f;
        float leftActivationAccumulator = 0f;
        float rightActivationAccumulator = 0f;

        PlayerInputActions playerInputActions;
        ICharacter character;
        IFactory factory;

        IActivator activator;

        GameObject itemDisplay = null;

        public void Awake()
        {
            playerInputActions = new PlayerInputActions();
            playerInputActions.Player.Enable();

            character = GetComponent<ICharacter>();
            factory = GameObject.Find("/DontDestroyOnLoad").GetComponent<IFactory>();
        }

        public void Update()
        {
            //initializers
            character.getOrientation.Forward(userCamera.transform.forward);
            character.getAnimation.SetSpeed(0f);
            character.getAnimation.SetVelocity(Vector3.zero);

            //movement
            if (playerInputActions.Player.Movement.IsPressed())
                Move();

            //toggle flashlight
            if (playerInputActions.Player.ToggleFlashlight.WasPerformedThisFrame())
                flashlightAnimator.SetTrigger("Toggle");

            //interact
            if (playerInputActions.Player.Interact.WasPressedThisFrame())
                Interact();
            
            //left hand interact
            if (playerInputActions.Player.LeftInteract.WasPressedThisFrame())
                leftActivationAccumulator = 0f;

            if (playerInputActions.Player.LeftInteract.IsPressed())
                leftActivationAccumulator += Time.deltaTime;

            if (playerInputActions.Player.LeftInteract.WasReleasedThisFrame())
                LeftHandInteract();

            //right hand interact
            if (playerInputActions.Player.RightInteract.WasPressedThisFrame())
                rightActivationAccumulator = 0f;

            if (playerInputActions.Player.RightInteract.IsPressed())
                rightActivationAccumulator += Time.deltaTime;

            if (playerInputActions.Player.RightInteract.WasReleasedThisFrame())
                RightHandInteract();

            //left hand drop
            if (leftActivationAccumulator > dropDuration)
                leftHandDrop();

            //right hand drop
            if (rightActivationAccumulator > dropDuration)
                RightHandDrop();
        }

        public void leftHandDrop()
        {
            leftActivationAccumulator = 0f;
            character.getEquipped.DropLeftHandEquipment();
        }

        public void RightHandDrop()
        {
            rightActivationAccumulator = 0f;
            character.getEquipped.DropRightHandEquipment();
        }

        public void Move()
        {
            Vector3 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
            Vector3 inputVector3D = new Vector3(inputVector.x, 0f, inputVector.y);
            float speedMultiplier = (character.getStats.GetAttribute("Thrill") / 100f) + 1;
            character.getAnimation.AddVelocity(inputVector3D * speedMultiplier);

            if (Input.GetKey(KeyCode.LeftShift))
                character.getAnimation.SetSpeed(2f);
            else
                character.getAnimation.SetSpeed(1f);             
        }

        public void Interact()
        {
            bool hashit = Physics.Raycast(new Ray(userCamera.transform.position, userCamera.transform.forward), out RaycastHit hitInfo, 5f);

            if (!hashit || hitInfo.transform.tag == "IgnorePlayer")
                return;

            activator = hitInfo.transform.GetComponent<IActivator>();

            if (activator == null)
                return;

            activator.impactPosition = hitInfo.point;
            activator.userPosition = character.getPosition;
            activator.user = character;
            activator.Activate();
        }

        public void LeftHandInteract()
        {
            if (character.getEquipped.isLeftHandOccupied)
            {
                character.getEquipped.LeftHandInteract();
                return;
            }

            bool hashit = Physics.Raycast(new Ray(userCamera.transform.position, userCamera.transform.forward), out RaycastHit hitInfo, 5f);

            if (!hashit) 
                return;           

            activator = hitInfo.transform.GetComponent<IActivator>();

            if (activator == null)
                return;

            activator.impactPosition = hitInfo.point;
            activator.userPosition = character.getPosition;
            activator.user = character;
            activator.LeftHandInteract();
        }

        public void RightHandInteract()
        {
            if (character.getEquipped.isRightHandOccupied)
            {
                character.getEquipped.RightHandInteract();
                return;
            }

            bool hashit = Physics.Raycast(new Ray(userCamera.transform.position, userCamera.transform.forward), out RaycastHit hitInfo, 5f);

            if (!hashit)
                return;

            activator = hitInfo.transform.GetComponent<IActivator>();

            if (activator == null)
                return;

            activator.impactPosition = hitInfo.point;
            activator.userPosition = character.getPosition;
            activator.user = character;
            activator.RightHandInteract();
        }
    }
}