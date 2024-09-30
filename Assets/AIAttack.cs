using System.Collections;
using UnityEngine;

public class AIAttack : MonoBehaviour {
    [SerializeField]float attackRange = 10f;
    [SerializeField] float attackSpeed = 1f;
    [SerializeField] bool canAttack = true;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float predictionOffset = .1f;
    [SerializeField] LevelVariables levelData;
    
    // Start is called before the first frame update
    void Start() {
        levelData = LevelVariables.Instance;
    }

    // Update is called once per frame
    void Update() {
        RotateToTarget();
        if (canAttack && IsInAttackRange()) {
			StartCoroutine(attackTimer());
			SpawnBullet();
            predictionOffset = Random.Range(-0.1f, .1f);
		}
	}

    void RotateToTarget() {
        Vector3 dir = levelData.playerMoveManager.PredictedMovement(predictionOffset) - transform.position;
        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10f * Time.deltaTime);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = rot;
    }

	private void SpawnBullet() {
		Projectile projectileThrown = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation).GetComponent<Projectile>();

		RaycastHit hit;
		Vector3 forceDir = Vector3.zero;
		if (Physics.Raycast(bulletSpawnPoint.position, bulletSpawnPoint.forward, out hit, 50f)) {
			forceDir = (hit.point - bulletSpawnPoint.transform.position).normalized;
		}
		projectileThrown.forceDirection = forceDir;
	}

	bool IsInAttackRange() {
        if(Vector3.Distance(levelData.playerTransform.position, transform.position) < attackRange) {
            return true;
        } else {
            return false;
        }
    }


    IEnumerator attackTimer() {
        canAttack = false;
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }

	private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}
