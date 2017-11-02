using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainMonsterMovement : MonoBehaviour {

	public float waveDistanceMultiplier;
	public Transform[] waypoints;
	public Animator monsterFSM;
	public GameObject waveProjector;
	public float stepInterval = 0.5f;

	private NavMeshAgent monsterNavigationMesh;

	private Vector3 currentWaypoint;
	private int waypointIndex;
	private float nextStep;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player"))
			FindObjectOfType<GameManager> ().Die ();
	}

	void Start () {
		monsterNavigationMesh = gameObject.GetComponent<NavMeshAgent> ();
		currentWaypoint = gameObject.transform.position;
		waypointIndex = 0;
	}

	void Update () {
		monsterFSM.SetFloat("WaypointDistance", Vector3.Distance(currentWaypoint, gameObject.transform.position));
		if (nextStep < Time.time)
			CreateWave ();
	}

	void CreateWave() {
		GameObject wave = Instantiate (waveProjector, 
			new Vector3 (gameObject.transform.position.x, 8.0f, gameObject.transform.position.z), 
			waveProjector.transform.rotation);

		nextStep = Time.time + stepInterval;
	}

	public void soundCreated(GameObject soundWave) {
		float distanceToSound = Vector3.Distance (gameObject.transform.position, soundWave.transform.position);
		if (distanceToSound <= waveDistanceMultiplier * soundWave.GetComponent<ScannerMovement>().waveDistance) {
			monsterFSM.SetFloat ("WaypointDistance", distanceToSound);
			currentWaypoint = soundWave.transform.position;
			monsterNavigationMesh.SetDestination (currentWaypoint);
		}

		Debug.Log (distanceToSound.ToString ());
		Debug.Log ((waveDistanceMultiplier * soundWave.GetComponent<ScannerMovement> ().waveDistance).ToString ());
	}

	public void SelectWaypoint() {
		waypointIndex++;
		if (waypointIndex > waypoints.Length - 1)
			waypointIndex = 0;
		Transform nextWaypoint = waypoints [waypointIndex]; 
		float distance = Vector3.Distance (nextWaypoint.position, gameObject.transform.position);

		monsterFSM.SetFloat ("WaypointDistance", distance);
		currentWaypoint = nextWaypoint.transform.position;

		monsterNavigationMesh.SetDestination (currentWaypoint);
	}
}
