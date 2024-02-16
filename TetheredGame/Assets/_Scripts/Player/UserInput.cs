using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TG.UserPlayer
{
    public class UserInput : MonoBehaviour
    {
        [SerializeField] Camera userCamera;
        private CharacterController controller;
        private PlayerInput playerInput;
        PlayerInputActions playerInputActions;
        ICharacter character;

        public void Awake()
        {
            controller = GetComponent<CharacterController>();
            playerInput = GetComponent<PlayerInput>();

            playerInputActions = new PlayerInputActions();
            playerInputActions.Player.Enable();

            character = GetComponent<ICharacter>();
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
            else
            {

            }

            

            
        }

        public void Movement(Vector2 inputVector)
        {
            float speed = 10f;
            
            Vector3 inputVector3D = new Vector3(inputVector.x, 0f, inputVector.y);
            character.getAnimation.AddVelocity(inputVector3D); //* character.getAnimation.GetSpeed());
            
        }
    }
}