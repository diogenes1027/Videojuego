using UnityEngine;
using System.Collections;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[SerializeField] private LayerMask layer_;
		[Header("Character Input Values")]

		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool attack;

		private bool bCoold = true;

		private bool bAttackAction = false;

		Transform childDetach;

		GameObject objectHolding;
		AnimMovement animMovement;




		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		public bool Item { get; set; }
		public bool Farm { get; set; }


		private void Start()
		{
			childDetach = transform.GetChild(3);
		}
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}


		public void OnLook(InputValue value)
		{
			if (cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}
		public void OnAttack(InputValue value)
		{
			AttackInput(value.isPressed);

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
		public void AttackInput(bool newAttackState)
		{
			if (bCoold && !bAttackAction)
			{
				attack = newAttackState;
				bCoold = false;

				AttackCast();
				StartCoroutine(ResetAttack());
            }
            else if (bAttackAction)
            {
				childDetach.DetachChildren();
				
				animMovement.Throw();
				bAttackAction = false;
			}
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

		private void AttackCast()
		{
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hitData;

			if (Physics.Raycast(ray, out hitData, 5, layer_))
			{
				
				objectHolding = hitData.transform.gameObject;
				animMovement = objectHolding.GetComponent<AnimMovement>();
				Debug.Log("Cast");
				if (objectHolding.CompareTag("HitObject") )
				{
					animMovement.DisableHitObject(false);
					objectHolding.transform.SetParent(childDetach);
					objectHolding.transform.position = transform.position + ((transform.forward+Vector3.up) * 1f);
					bAttackAction = true;
				}
			}
		}

		IEnumerator ResetAttack()
		{
			yield return new WaitForSeconds(1.0f);
			attack = false;
			bCoold = true;
			
		}
		
	
	}
	
}