using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
        public bool aim;
        public bool shoot;

		public bool analogMovement;

		public bool cursorLocked = true;
		public bool cursorInputForLook = true;


		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}
        public void OnShoot(InputValue value)
        {
            ShootInput(value.isPressed);
        }
        public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
        public void OnAim(InputValue value)
        {
            AimInput(value.isPressed);
        }

        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}
        public void ShootInput(bool newShootState)
        {
            shoot = newShootState;
        }
        public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
        public void AimInput(bool newAimState)
        {
            aim = newAimState;
        }

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}