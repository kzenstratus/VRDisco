using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class NameScript : NetworkBehaviour {



	public bool nameSet = false;
	public uint id;
	//on server


	//	public int localConn;

	List<string> names = new List<string>();

	void Start(){
		//numConnections = -1;
		names.Add("ONE");
		names.Add("TWO");
		names.Add("THREE");
		names.Add("FOUR");
		names.Add("FIVE");
		names.Add("SIX");
	

		id = GetComponent<NetworkIdentity>().netId.Value;
		gameObject.transform.GetChild (0).GetComponent<TextMesh> ().text = names [((int)(id - 1)) % 6];
	}

	//
//	[ClientRpc]
//	public void RpcConnection(int con){
//		//if (gameObject.transform.GetChild (0).GetComponent<TextMesh> ().text == " ") {
//		if (!nameSet) {
//			gameObject.transform.GetChild (0).GetComponent<TextMesh> ().text = names [con];
//			nameSet = true;
//		} else {
//			return;
//		}
//		//}//
//	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.GetChild(0).transform.position = new Vector3 (gameObject.transform.position.x, -2.3f, gameObject.transform.position.z);
		//		if (Network.isServer) {
		//			int numCon = Network.connections.Length;
		//RpcConnection ();
		//		}

	}
		
}
