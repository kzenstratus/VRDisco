using UnityEngine;
using System.Collections;
using System.IO;


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
