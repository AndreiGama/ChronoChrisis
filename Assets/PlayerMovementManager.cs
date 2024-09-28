using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementManager : MonoBehaviour {
	CharacterController charController;
	[SerializeField] float gravity = -9.81f;
    [SerializeField] float moveSpeed;

	[SerializeField] Transform groundCheck;
	[SerializeField] float groundDistance;
	[SerializeField] LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;
	[SerializeField] static Vector2 playerInput;
	private void Awake() {
		charController = GetComponent<CharacterController>();
	}
	public static void MoveInput(CallbackContext context) {
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
}
