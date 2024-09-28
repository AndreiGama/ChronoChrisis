using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerFireManager : MonoBehaviour {
	[SerializeField] float interactRange = 8f;
	public bool itemEquipped = false;
	public GameObject equippedItemOBJ;
	public Transform equipmentSlotPosition;
	[SerializeField] Transform cam;

	public void OnFire(CallbackContext context) {
		if (context.performed && itemEquipped == false) {
			Interact();
		} else if(context.performed && itemEquipped) {
			Throw();
		}
	}

	private void Interact() {
		RaycastHit hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange)) {
			IInteract objInteract = hit.transform.GetComponent<IInteract>();
			if (objInteract != null) {
				objInteract.Interact(this);
			}
		}
	}

	private void Throw() {
		if (itemEquipped == true) {
			Projectile projectileThrown = Instantiate(equippedItemOBJ, cam.transform.position, cam.rotation).GetComponent<Projectile>();
			
			RaycastHit hit;
			Vector3 forceDir = Vector3.zero;
			if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 500f)) {
				forceDir = (hit.point - cam.transform.position).normalized;
			}
			projectileThrown.forceDirection = forceDir;
			itemEquipped = false;
			equippedItemOBJ = null;
			Destroy(equipmentSlotPosition.GetChild(0).gameObject);
		}
	}
}


