using UnityEngine;

public class StateManager : MonoBehaviour {
	State currentState;

	void Update() {
		RunStateMachine();
	}

	void RunStateMachine() {
		State nextState = currentState?.RunCurrentState();

		if (nextState != null) {
			SwitchToTheNextState(nextState);
		}
	}

	void SwitchToTheNextState(State nextState) {
		currentState = nextState;
	}
}