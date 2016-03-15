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

	List<Color> colors = new List<Color>();

	void Start(){
		//numConnections = -1;
		names.Add("Kevin");
		names.Add("Max");
		names.Add("Kwaku");
		names.Add("Stephen");
		names.Add("Klay");
		names.Add("Draymond");

		colors.Add (new Color(0.8F, 0.9F, 0.4F));
		colors.Add (new Color(0.1F, 0.7F, 0.1F));
		colors.Add (new Color(0.4F, 0.3F, 0.9F));
		colors.Add (new Color(0.2F, 0.7F, 0.8F));
		colors.Add (new Color(0.9F, 0.3F, 0.3F));
		colors.Add (new Color(0.74F, 0.13F, 0.42F));

		id = GetComponent<NetworkIdentity>().netId.Value;
		GetComponent<Renderer> ().material.color = colors [((int)(id - 1)) % colors.Count];
		gameObject.transform.GetChild (0).GetComponent<TextMesh> ().text = names [((int)(id - 1)) % names.Count];
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
