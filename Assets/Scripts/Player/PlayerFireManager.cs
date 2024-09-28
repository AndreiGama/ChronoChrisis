using UnityEngine;

public class PlayerFireManager : MonoBehaviour {
	[SerializeField] float interactRange = 8f;
	public bool itemEquipped = false;
	public GameObject equippedItemOBJ;
	public Transform equipmentSlotPosition;
	[SerializeField]Transform cam;
	
	public void OnFire() {
		if (!itemEquipped) {
			Interact();
		} else {
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
		Instantiate(equippedItemOBJ, cam.transform.position, Quaternion.identity);
		itemEquipped = false;
		equippedItemOBJ = null;
		Destroy(equipmentSlotPosition.GetChild(0).gameObject);
	}
}


