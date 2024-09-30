using System.Collections;
using UnityEngine;

public class PlayerPowerManager : MonoBehaviour
{
	[SerializeField] bool canUseAbility = true;
    [SerializeField] float cooldownAbility = 20f;
    [SerializeField] float AbilityUsageTime = 10f;
    LevelVariables levelVariables;
	[SerializeField] bool affectTime;
	[SerializeField] float slowdownFactor = .05f;
	PlayerMovementManager playerMovementManager;
	PlayerCameraManager playerCameraManager;
	private void Awake() {
		playerMovementManager = GetComponent<PlayerMovementManager>();
		playerCameraManager = Camera.main.GetComponent<PlayerCameraManager>();
	}
	private void Start() {
		levelVariables = LevelVariables.Instance;
	}

	public void OnAbilityUsage() {
		if (canUseAbility) {
			StartCoroutine(CooldownAbility1());
			StartCoroutine(AbillityUsing());
		}
	}

	void AbilitySlow() {
		Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * .02f;
	}
	void AbilityRevertSlow() {
		Time.timeScale = 1f;
	}
	IEnumerator AbillityUsing() {
		affectTime = true;
		yield return new WaitForSecondsRealtime(AbilityUsageTime);
		affectTime = false;
	}
	IEnumerator CooldownAbility1() {
		canUseAbility = false;
		yield return new WaitForSecondsRealtime(cooldownAbility);
		canUseAbility = true;
	}
	//bugged
	private void Update() {
		if (affectTime && playerCameraManager.mouseInput == Vector2.zero && playerMovementManager.playerInput == Vector2.zero) {
			AbilitySlow();
		} else if(affectTime && playerCameraManager.mouseInput != Vector2.zero && playerMovementManager.playerInput != Vector2.zero) {
			AbilityRevertSlow(); 
		} else if (!affectTime) {
			AbilityRevertSlow();
		}
	}
}
