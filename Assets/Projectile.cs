using UnityEngine;

public class Projectile : MonoBehaviour {
	Rigidbody rb;
	[SerializeField] float throwForce;
	[SerializeField] float throwUpForce;
	public Vector3 forceDirection;
	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}
	void Start() {
		Vector3 forceToAdd = transform.forward * throwForce + transform.up * throwUpForce;
		rb.AddForce(forceToAdd, ForceMode.Impulse);
	}
	//private void Update() {
	//	rb.velocity += transform.forward * projectileSpeed * Time.deltaTime;
	//}
	private void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.transform.name);
		Destroy(gameObject);
	}
}
