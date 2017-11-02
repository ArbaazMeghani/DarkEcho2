using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainMonsterMovement : MonoBehaviour {

	public float waveDistanceMultiplier;
	public Transform[] waypoints;
	public Animator monsterFSM;

	private NavMeshAgent monsterNavigationMesh;

	private Transform currentWaypoint;
	private int waypointIndex;

	void Start () {
		monsterNavigationMesh = gameObject.GetComponent<NavMeshAgent> ();
		currentWaypoint = gameObject.transform;
		waypointIndex = 0;
	}

	void Update () {
		monsterFSM.SetFloat("WaypointDistance", Vector3.Distance(currentWaypoint.position, gameObject.transform.position));
	}

	public void soundCreated(GameObject soundWave) {
		float distanceToSound = Vector3.Distance (gameObject.transform.position, soundWave.transform.position);
		if (distanceToSound <= waveDistanceMultiplier) {
			monsterFSM.SetBool ("SoundHeard", true);
			monsterFSM.SetFloat ("WaypointDistance", distanceToSound);
			currentWaypoint = soundWave.transform;
		}
	}

	public void SelectWaypoint() {
		waypointIndex++;
		if (waypointIndex > waypoints.Length - 1)
			waypointIndex = 0;
		Transform nextWaypoint = waypoints [waypointIndex]; 
		float distance = Vector3.Distance (nextWaypoint.position, gameObject.transform.position);

		monsterFSM.SetFloat ("WaypointDistance", distance);
		currentWaypoint = nextWaypoint;

		monsterNavigationMesh.SetDestination (currentWaypoint.position);
	}
}
