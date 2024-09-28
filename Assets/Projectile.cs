using UnityEngine;

public class Projectile : MonoBehaviour {
	Rigidbody rb;
	[SerializeField] float projectileSpeed;
	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}
	private void Update() {
		rb.velocity += transform.forward * projectileSpeed * Time.deltaTime;
	}
	private void OnCollisionEnter(Collision collision) {
		Destroy(gameObject);
	}
}
