using Unity.VisualScripting;
using UnityEngine;

public class StunGrenade : Grenade {
	[SerializeField] float stunTime = 5f;
	[SerializeField] float explosionRange = 5f;
	[SerializeField] Material stunnedMaterial;
	[SerializeField] LayerMask enemyLayerMask;
	public override void Impact() {
		Debug.Log("Impact");
		RaycastHit[] hits = Physics.SphereCastAll(transform.position, explosionRange, transform.up, explosionRange, enemyLayerMask);
		Debug.Log("Hits amount: " + hits.Length);

		foreach (RaycastHit hit in hits) {
			StunnedAI script = hit.transform.AddComponent<StunnedAI>();
			script.enabled = true;
			script.stunnedMaterial = stunnedMaterial;
		}
		Destroy(gameObject);
	}
}
