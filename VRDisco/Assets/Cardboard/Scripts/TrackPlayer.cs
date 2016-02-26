using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TrackPlayer : NetworkBehaviour {
	private CardboardHead head;

	private Vector3 offset;
	public GameObject me;

	void Start()  {
		head =Camera.main.GetComponent<StereoController>().Head;
		me =GameObject.FindWithTag("Player");
	}

	void LateUpdate() {

		// head.transform.position = thelook positon of the head on the plane
		// head.Gaze.direction = positon of where the head is looking
		if (me != null) {
			offset = head.Gaze.direction + head.transform.position;
//			playerObject.transform.Translate (direction);
			me.transform.position = me.transform.position + offset;


		}
	}
}