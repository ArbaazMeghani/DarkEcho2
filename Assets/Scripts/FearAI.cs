using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FearAI : MonoBehaviour {

	public Transform[] waypoints;
    public Transform door;
    public Vector3 des;
	public float stepInterval = 0.5f;
	public GameObject waveProjector;

	private Animator animationController;
	private NavMeshAgent navMesh;
	private float distanceToWaypoint;
	private int waypointIndex;
	private float nextStep;
    private float timer = 0;

	void Start () {
		animationController = gameObject.GetComponent<Animator> ();
		navMesh = gameObject.GetComponent<NavMeshAgent> ();
		waypointIndex = 0;
		nextStep = 0.0f;
		SetDestination ();

	}

	void Update() {

        timer += Time.deltaTime;

        runToDoor(timer);

		if (Input.GetButton ("Fire1"))
			KillScientist ();

		if (!animationController.enabled) {
			navMesh.enabled = false;
			return;
		}
		CalculateDistance ();
		if (distanceToWaypoint <= 1.0f)
			SetDestination ();

		if (nextStep < Time.time)
			CreateWave ();
	}

	void CreateWave() {

		GameObject wave = Instantiate (waveProjector, 
			new Vector3 (gameObject.transform.position.x, 8.0f, gameObject.transform.position.z), 
			waveProjector.transform.rotation);

		nextStep = Time.time + stepInterval;
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

    void runToDoor(float timer)
    {

        if (timer >= 16.0f)
        {
            gameObject.active = false;
        }

        if (timer >= 5.0f)
        {
            des = door.position;
            navMesh.destination = des;
        }

    }
}
