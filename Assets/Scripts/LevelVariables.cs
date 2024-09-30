using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVariables : MonoBehaviour {
	private static LevelVariables instance;
	public static LevelVariables Instance {
		get {
			return instance;
		}
	}
    public Transform playerTransform;
	public PlayerMovementManager playerMoveManager;
	private void Awake() {
		playerTransform = GameObject.Find("Player").GetComponent<Transform>();
		playerMoveManager = GameObject.Find("Player").GetComponent<PlayerMovementManager>();
		instance = this;
		// Make sure make this viable for multi levels or keep in mind when making multiple levels.
	}
	// Start is called before the first frame update
	void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
