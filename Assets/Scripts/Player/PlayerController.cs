using UnityEngine;
using UnityEngine.InputSystem;
using Lero.Character;

namespace Lero.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        CharacterMovement _characterMovement;

        private InputSystem_Actions _inputActions;

        private void OnEnable()
        {
            if (_inputActions == null)
                _inputActions = new InputSystem_Actions();

            _inputActions.Player.Move.performed += OnMove;
            _inputActions.Player.Move.canceled += OnMove;
            _inputActions.Player.Enable();
        }

        private void OnDisable()
        {
            if (_inputActions == null)
                return;

            _inputActions.Player.Move.performed -= OnMove;
            _inputActions.Player.Move.canceled -= OnMove;
            _inputActions.Player.Disable();
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            if (_characterMovement == null)
                return;

            Vector2 input = ctx.ReadValue<Vector2>();
            Vector3 dir = new Vector3(input.x,  input.y, 0f);

            if (dir.sqrMagnitude > 0.0001f)
            {
                dir.Normalize();
                _characterMovement.SetDirection(dir);
                _characterMovement.StartMovement();
            }
            else
            {
                _characterMovement.StopMovement();
            }
        }
    }
}

