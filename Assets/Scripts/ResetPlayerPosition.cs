using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour {

	void Start() {
		gameObject.transform.position = new Vector3 (-16.2f, 6.91f, -6.7f);
	}
}
