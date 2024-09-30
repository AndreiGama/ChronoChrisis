using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerCameraManager : MonoBehaviour
{
    [SerializeField] float cameraSensitivity = 100f;
    [SerializeField] Transform playerBody;
    float xRotation;
    public Vector2 mouseInput;
    private void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}
    public void LookInput(CallbackContext context) {
        mouseInput = context.ReadValue<Vector2>();
    }
    public bool IsLooking() {
        if(mouseInput != Vector2.zero) {
            return true;
        } else {
            return false;
        }
    }
	// Update is called once per frame
	void Update()
    {
        float mouseX = mouseInput.x * cameraSensitivity * Time.deltaTime;
		float mouseY = mouseInput.y * cameraSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
