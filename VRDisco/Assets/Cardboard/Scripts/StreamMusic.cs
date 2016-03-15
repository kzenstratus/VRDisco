using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using System.Collections.Generic;


public class StreamMusic : NetworkBehaviour {


	[SyncVar]
	public string songName;

//	public string songName;
	[SyncVar]
	int currentIndex;

//	[SyncVar]
//	public AudioSource source1;


	List<string> songs = new List<string>();

	void Start(){
		songs.Add("Faded");
		songs.Add("Force");
		songs.Add("Genesis");
		songs.Add("Happiest man on earth");
		songs.Add("Leave a trace");
		songs.Add("No Gravity");
		songs.Add("Open Season");
		songs.Add("Runaway");
		songs.Add("Say my name");
		songs.Add("Surreal");
		songs.Add("Wizard");
	}


	[ClientRpc]
	public void RpcPlaySong(string current){

		songName = current;
		AudioSource source1 = GetComponent<AudioSource>();
		source1.loop = true;
		source1.clip = Resources.Load(songName) as AudioClip;
		source1.Play ();
	}

	[ClientRpc]
	public void RpcStopSong(){
		AudioSource s2;
		s2 = GetComponent<AudioSource>();
		s2.Stop ();
	}

	[Server]
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.N)) 
		{
			currentIndex = (currentIndex + 1) % songs.Count;
			string current = songs[currentIndex];
			RpcPlaySong(current);
		}
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			RpcStopSong();
		}

	}
		
}


