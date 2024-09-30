using System.Collections;
using UnityEngine;

public class StunnedAI : MonoBehaviour {
	AIAttack aiAttackScript;
	MeshRenderer meshRenderer;
	Material material;
	public Material stunnedMaterial;
	[SerializeField] float stunTime = 5f;
	void Awake() {
		aiAttackScript = GetComponent<AIAttack>();
		meshRenderer = GetComponent<MeshRenderer>();
		material = meshRenderer.material;
	}
	private void Start() {
		StartCoroutine(StunCoroutine());
	}
	private IEnumerator StunCoroutine() {
		aiAttackScript.enabled = false;
		Material ogMaterial = meshRenderer.material;
		meshRenderer.material = stunnedMaterial;
		yield return new WaitForSeconds(stunTime);
		aiAttackScript.enabled = true;
		meshRenderer.material = ogMaterial;
		Destroy(this);
	}
}