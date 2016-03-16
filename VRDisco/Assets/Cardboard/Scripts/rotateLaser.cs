using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using System.Collections.Generic;

public class rotateLaser : MonoBehaviour {

	private Quaternion localRotation;
//	public float _Angle = 30;
//	public float _Period = 1;
	public float minAngle;
	public float maxAngle;
	public float speed;
	private float _Time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate(Vector3.right * Time.deltaTime);
//		_Time = _Time + Time.deltaTime;
//		float phase = Mathf.Sin(_Time / _Period);
//		gameObject.transform.rotation = Quaternion.Euler( new Vector3(0, phase * _Angle, 0));

//		localRotation.y = Mathf.Clamp(Time.deltaTime,-30,30);
//		gameObject.transform.rotation = localRotation;
		//gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y + 1, gameObject.transform.rotation.z);

		float angle = Mathf.LerpAngle(minAngle, maxAngle, Mathf.PingPong(Time.time / speed, 1.0f));
		gameObject.transform.eulerAngles = new Vector3(0, angle, 0);
	
	}
}
