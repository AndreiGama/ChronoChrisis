using UnityEngine;

public class Pickup : MonoBehaviour, IInteract {
	[SerializeField] GameObject prefabPickup;
	[SerializeField] GameObject prefabPickupModel;
	
	public void Interact(PlayerFireManager fireManager) {
		fireManager.equippedItemOBJ = prefabPickup;
		Instantiate(prefabPickupModel, fireManager.equipmentSlotPosition);
		fireManager.itemEquipped = true;
		Destroy(gameObject);
	}
}
