using UnityEngine;

public class PlayerMovementManager : MonoBehaviour {
	CharacterController charController;
	[SerializeField] float gravity = -9.81f;
    [SerializeField] float moveSpeed;

	[SerializeField] Transform groundCheck;
	[SerializeField] float groundDistance;
	[SerializeField] LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;
	private void Awake() {
		charController = GetComponent<CharacterController>();
	}

	private void Update() {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		if (isGrounded && velocity.y < 0) {
			velocity.y = -2f;
		}
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		Vector3 move = transform.right * x + transform.forward * z;
		charController.Move(move * moveSpeed * Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;
		charController.Move(velocity * Time.deltaTime);
	}
}
