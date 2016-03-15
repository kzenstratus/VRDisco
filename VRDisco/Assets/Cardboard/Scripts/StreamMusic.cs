using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using System.Collections.Generic;


public class StreamMusic : NetworkBehaviour {


//	[SyncVar]
//	public string songName;

	//public static string staticSong;

	public static int songIndex;

//	[SyncVar]
//	int currentIndex;

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
	public void RpcPlaySong(int index){
		string nowName = songs[index];
		//songName = nowName;
		AudioSource source1 = GetComponent<AudioSource>();
		source1.loop = true;
		source1.clip = Resources.Load(nowName) as AudioClip;
		source1.Play ();
	}

//	[ClientRpc]
//	public void RpcUpdateSong(int index){
//		currentIndex = index;
//	}

	[ClientRpc]
	public void RpcPauseSong(){
		AudioSource s2;
		s2 = GetComponent<AudioSource>();
		if (s2.isPlaying) {
			s2.Pause ();
		} else {
			s2.UnPause ();
		}
	}

	[Server]
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.P)) {
			//int newIndex = (songIndex + 1) % songs.Count;
			//int nowIndex = (songIndex + 1) % songs.Count;
			//string current = songs[currentIndex];
			RpcPlaySong (songIndex);
			//nsongIndex = (songIndex + 1) % songs.Count;
		}
		
			if (Input.GetKeyDown (KeyCode.Space)) {
				RpcPauseSong ();
			}

			if (Input.GetKeyDown (KeyCode.N)) {
				songIndex = (songIndex + 1) % songs.Count;
			}

	}
		
		
}


