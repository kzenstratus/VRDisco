
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.VR;

// phone IP : 10.150.40.208
<<<<<<< HEAD
//mac IP :10.150.12.108
=======
//mac IP :10.150.5.252
>>>>>>> network
public class Net_Hud : MonoBehaviour {
	public string hostIP;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startClient(){
		NetworkManager netman = GetComponent<NetworkManager> ();
		netman.networkAddress = hostIP;
		netman.networkPort = 7777;
		netman.StartClient();

	}
	public void startHost(){
		NetworkManager netman = GetComponent<NetworkManager> ();
		netman.networkAddress = hostIP;
		netman.StartHost();
	}
}
