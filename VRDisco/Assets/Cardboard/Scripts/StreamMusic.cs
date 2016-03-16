using UnityEngine;
using System.Collections;
using System.IO;
<<<<<<< HEAD


public class StreamMusic : MonoBehaviour {

//	public string url1 = "http://149.13.0.80:80/radio1rock.ogg";
//	public string url2 = "http://ai-radio.org:8000/128.ogg";
	public string url3 = "http://upload.wikimedia.org/wikipedia/en/9/9f/Sample_of_%22Another_Day_in_Paradise%22.ogg";
//	public string url4 = "http://upload.wikimedia.org/wikipedia/en/4/45/ACDC_-_Back_In_Black-sample.ogg";
//	public string url5 = "http://www.stephaniequinn.com/Music/Pachelbel%20-%20Canon%20in%20D%20Major.mp3";
	public string url5;
//	public string url2 = "/Music/leave_a_trace.ogg";

	void Start(){
		if (Application.platform == RuntimePlatform.Android) {
			print ("Android");
			url5 = "http://www.stephaniequinn.com/Music/Pachelbel%20-%20Canon%20in%20D%20Major.mp3";
		} else if (Application.platform == RuntimePlatform.OSXEditor) {
			print ("On the mac");
			url5 = "http://upload.wikimedia.org/wikipedia/en/4/45/ACDC_-_Back_In_Black-sample.ogg";
		} else if (Application.platform == RuntimePlatform.OSXPlayer) {
			url5 = "http://upload.wikimedia.org/wikipedia/en/4/45/ACDC_-_Back_In_Black-sample.ogg";
		}
	}

		void Update()
	{
//		if (Input.GetKeyDown(KeyCode.N)) this.Tune(this.url1);
//		if (Input.GetKeyDown(KeyCode.M)) this.Tune(this.url3);
//		if (Input.GetKeyDown(KeyCode.N)) this.Tune(this.url4);
//		if (Input.GetKeyDown(KeyCode.B)) this.Tune(this.url5);
//		this.Tune (this.url5);

//		if (Input.GetKeyDown(KeyCode.B)) this.Tune(this.url2);
	}

		public void Tune(string url)
	{
		this.StopAllCoroutines();
		this.StartCoroutine(this.__Tune(url5));
	}
	IEnumerator __Tune(string url)
	{
		var www = new WWW(url);

		var source = GetComponent<AudioSource>();

//		source.clip = www.GetAudioClip (false, false, AudioType.OGGVORBIS);
		source.clip = www.GetAudioClip (false, false);

//
		while (!(source.clip.loadState == AudioDataLoadState.Loaded)) {
			yield return null;
		}

		this.GetComponent<AudioSource>().clip = source.clip;
		this.GetComponent<AudioSource>().Play ();
	}

}


//public class StreamMusic : MonoBehaviour {
//
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
=======
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


>>>>>>> network
