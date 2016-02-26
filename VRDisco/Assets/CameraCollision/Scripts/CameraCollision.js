#pragma strict
//THIS SCRIPT IS USED TO PREVENT THE CAMERA FROM GOING THROUGH WALLS
//ATTACH THIS SCRIPT TO A CAMERA

var canScroll = true; //whether or not you can zoom in and out
var focusPoint : Transform; //used as the focal rotation point, and raycast point | must be centered on the player(x and z)
var detectionRadius : float = 0.15; //radius detection | used to prevent the camera from peering through when standing up against a wall
var zoomDistance : float = 1; //the distance the camera will zoom per scroll
var maxZoomOut : int = 5; //used to limit distance you can zoom out, away from your character
private var maxZoomIn : int; //used to limit distance you can zoom in, towards your character
private var hit : RaycastHit; //used to detect objects in front of camera
private var camFollow : GameObject; //monitors camera's position
private var camSpot : GameObject; //camera's destination | used for zooming camera in and out
//IF YOU WISH TO USE ANOTHER SCRIPT, ALONG WITH THIS ONE, THAT INCORPERATES ZOOMING, YOU MUST ZOOM THIS VARIABLE [camSpot], NOT THE CAMERA ITSELF!
//This variable is a gameObject, created on start (just below).

function Start () {
	//create camSpot
	camSpot = new GameObject();
	camSpot.transform.name = "CameraSpot";
	camSpot.transform.parent = transform.parent;
	camSpot.transform.position = transform.position;
	
	//create camFollow
	camFollow = new GameObject();
	camFollow.transform.name = "CameraFollow";
	camFollow.transform.parent = transform.parent;
	camFollow.transform.position = focusPoint.position;
	//make sure the camFollow is looking at the camera
	camFollow.transform.LookAt(transform);
	
	//Set maxZoomIn distance to not exceed starting distance from camera to focusPoint
	maxZoomIn = Vector3.Distance(transform.position, focusPoint.transform.position) / zoomDistance;
}
function Update () {
	//If player mouse-scrolls foward
	if(Input.GetAxis("Mouse ScrollWheel") > 0) {
		if(canScroll == true) {
			//can only zoom in four intervals from camSpot's starting pos
			if(maxZoomIn > 0) {
				//zoom camSpot in
				camSpot.transform.position = camSpot.transform.position + 1 * -camFollow.transform.forward;
				maxZoomOut += 1; maxZoomIn -= 1;
			}
		}
	}
	//If player mouse-scrolls backward
	if(Input.GetAxis("Mouse ScrollWheel") < 0) {
		if(canScroll == true) {
			//can only zoom out four intervals from camSpot's starting pos
			if(maxZoomOut > 0) {
				//zoom camSpot out
				camSpot.transform.position = camSpot.transform.position - 1 * -camFollow.transform.forward;
				maxZoomOut -= 1; maxZoomIn += 1;
			}
		}
	}
	
	//distance between camFollow and camSpot
	var distFromCamSpot : float = Vector3.Distance(camFollow.transform.position, camSpot.transform.position);
	//distance between camFollow and camera
	var distFromCamera : float = Vector3.Distance(camFollow.transform.position, transform.position);
	
	//ShereCast from camFollow to camSpot
	if(Physics.SphereCast(camFollow.transform.position, detectionRadius, camFollow.transform.forward, hit, distFromCamSpot)) {
		//**MAKE SURE YOUR PLAYER IS NOT BETWEEN THE FOCUS-POINT AND CAMERA**
		//get distance betwen camFollow and hitPoint of raycast
		var distFromHit = Vector3.Distance(camFollow.transform.position, hit.point);
		//if camera is behind an object, immediately put it in front
		if(distFromHit < distFromCamera) {
			//if player is ver close to a wall, bring camera inward, 
			//but do not exceed the camFollow's position (dont put camera in front of player)
			if(distFromCamera > 1) {
				transform.position = hit.point + 1 * -camFollow.transform.forward;
			}
			else {
				transform.position = camFollow.transform.position;
			}
		}
		else {
			//if player is ver close to a wall, bring camera inward, 
			//but do not exceed the camFollow's position (dont put camera in front of player)
			if(distFromCamera > 1) {
				transform.position = Vector3.MoveTowards(transform.position, hit.point + 1 * -camFollow.transform.forward, 5 * Time.deltaTime);
			}
			else {
				transform.position = Vector3.MoveTowards(transform.position, camFollow.transform.position, 5 * Time.deltaTime);
			}
		}
	}
	else {
		//ease camera back to camSpot
		transform.position = Vector3.MoveTowards(transform.position, camSpot.transform.position, 5 * Time.deltaTime);
	}
}