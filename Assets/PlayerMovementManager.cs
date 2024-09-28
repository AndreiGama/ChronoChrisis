using UnityEngine;

public class PlayerMovementManager : MonoBehaviour {
	CharacterController charController;
    [SerializeField] float moveSpeed;
	private void Awake() {
		charController = GetComponent<CharacterController>();
	}

	private void Update() {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		Vector3 move = transform.right * x + transform.forward * z;
		charController.Move(move * moveSpeed * Time.deltaTime);
	}
}
