using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScientistAI : MonoBehaviour {

	public Transform[] waypoints;

	private Animator animationController;
	private NavMeshAgent navMesh;
	private float distanceToWaypoint;
	private int waypointIndex;

	void Start () {
		animationController = gameObject.GetComponent<Animator> ();
		navMesh = gameObject.GetComponent<NavMeshAgent> ();
		waypointIndex = 0;
		SetDestination ();
	}

	void Update() {
		if (Input.GetButton ("Fire1"))
			KillScientist ();

		if (!animationController.enabled) {
			navMesh.enabled = false;
			return;
		}
		CalculateDistance ();
		if (distanceToWaypoint <= 1.0f)
			SetDestination ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Monster")) {
			Debug.Log ("COLLISION");
			KillScientist ();
		}
	}

	void KillScientist() {
		animationController.enabled = false;
	}

	void SetDestination() {
		ComputeWaypointIndex ();
		navMesh.SetDestination (waypoints [waypointIndex].position);
		CalculateDistance ();
	}

	void CalculateDistance() {
		distanceToWaypoint = Vector3.Distance(gameObject.transform.position, waypoints[waypointIndex].position);
	}

	void ComputeWaypointIndex() {
		waypointIndex++;
		if (waypointIndex >= waypoints.Length)
			waypointIndex = 0;
	}
}
