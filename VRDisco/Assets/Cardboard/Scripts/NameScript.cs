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

	//List<Color> colors = new List<Color>();

	List<string> textures = new List<string>();

	void Start(){
		//numConnections = -1;
		names.Add("Kevin");
		names.Add("Max");
		names.Add("Kwaku");
		names.Add("Stephen");
		names.Add("Klay");
		names.Add("Draymond");
		names.Add("Kobe");
		names.Add("Michael");

//		colors.Add (new Color(0.8F, 0.9F, 0.4F));
//		colors.Add (new Color(0.1F, 0.7F, 0.1F));
//		colors.Add (new Color(0.4F, 0.3F, 0.9F));
//		colors.Add (new Color(0.2F, 0.7F, 0.8F));
//		colors.Add (new Color(0.9F, 0.3F, 0.3F));
//		colors.Add (new Color(0.74F, 0.13F, 0.42F));

		//Resources.Load("glass") as Texture;
		textures.Add("cubes");
		textures.Add("shapes");
		textures.Add("pattern");
		textures.Add("images");
		textures.Add("colors");
		textures.Add("galaxy");


		id = GetComponent<NetworkIdentity>().netId.Value;
		GetComponent<Renderer> ().material.mainTexture = Resources.Load(textures[((int)(id - 1)) % textures.Count]) as Texture;
		//GetComponent<Renderer> ().material.color = colors [((int)(id - 1)) % colors.Count];
		gameObject.transform.GetChild (0).GetComponent<TextMesh> ().text = names [((int)(id - 1)) % names.Count];
	}


	// Update is called once per frame
	void Update () {
		gameObject.transform.GetChild(0).transform.position = new Vector3 (gameObject.transform.position.x, -1.8f, gameObject.transform.position.z);


	}
		
}
