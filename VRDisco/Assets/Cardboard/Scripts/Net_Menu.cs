
using UnityEngine;
using System.Collections;
using UnityEngine.VR;

// phone IP : 10.150.40.208
//mac IP :10.150.5.252
public class Net_Menu : MonoBehaviour {
	//public GameObject prefab;
	//public string hostIP;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(){
		
//		//Application.LoadLevelAdditive("DemoScene");
//		NetworkManager netman = GetComponent<NetworkManager> ();
//		netman.networkAddress = hostIP;
//		netman.networkPort = 7777;
//
//		netman.StartClient();
//
		Application.LoadLevel ("DemoScene"); 

		//GameObject.Instantiate(prefab);
	}
//	public void startHost(){
//		NetworkManager netman = GetComponent<NetworkManager> ();
//		netman.networkAddress = hostIP;
//		//Application.LoadLevel ("DemoScene"); 
//		netman.StartHost();
//
//		Application.LoadLevel ("DemoScene"); 
////
////		//GameObject.Instantiate(prefab);
//	}
}
