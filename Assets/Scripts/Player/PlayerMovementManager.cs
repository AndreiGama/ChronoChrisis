using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementManager : MonoBehaviour {
	CharacterController charController;
	[SerializeField] float gravity = -9.81f;
	public float moveSpeed;

	[SerializeField] Transform groundCheck;
	[SerializeField] float groundDistance;
	[SerializeField] LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;
	public  Vector2 playerInput;
	private void Awake() {
		charController = GetComponent<CharacterController>();
	}
	public void MoveInput(CallbackContext context) {
		playerInput = context.ReadValue<Vector2>();
		playerInput.Normalize();
	}
	private void Update() {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		if (isGrounded && velocity.y < 0) {
			velocity.y = -2f;
		}
		Vector3 move = transform.right * playerInput.x + transform.forward * playerInput.y;
		charController.Move(move * moveSpeed * Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;
		charController.Move(velocity * Time.deltaTime);
	}

	public Vector3 GetPlayerMovement() {
		Vector3 move = transform.right * playerInput.x + transform.forward * playerInput.y;
		Vector3 velocity = move * moveSpeed;

		return velocity;
	}

	public Vector3 PredictedMovement(float PredictionTime) {
		Vector3 predictedPosition = transform.position + GetPlayerMovement() * PredictionTime;

		return predictedPosition;
	}
}
