using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;


public class StreamMusic : NetworkBehaviour {

	//    public string url1 = "http://149.13.0.80:80/radio1rock.ogg";
	//    public string url2 = "http://ai-radio.org:8000/128.ogg";
	//    public string url3 = "http://upload.wikimedia.org/wikipedia/en/9/9f/Sample_of_%22Another_Day_in_Paradise%22.ogg";
	//    public string url4 = "http://upload.wikimedia.org/wikipedia/en/4/45/ACDC_-_Back_In_Black-sample.ogg";
	//    public string url5 = "http://www.stephaniequinn.com/Music/Vivaldi%20-%20Spring%20from%20Four%20Seasons.mp3";
	//    public string url5;
	//    private string tempUrl = "http://upload.wikimedia.org/wikipedia/en/4/45/ACDC_-_Back_In_Black-sample.ogg";
	//    private string tempUrl2 = "http://www.stephaniequinn.com/Music/Vivaldi%20-%20Spring%20from%20Four%20Seasons.mp3";
	//    public string url6 = "http://www.stephaniequinn.com/Music/Brahms%20Symphony%20-%20from%20Fourth%20Movement.mp3";
	//

	[SyncVar]
	public string songName;

	[SyncVar]
	public AudioSource source1;


	public string sorry = "I'm so sorry";
	public string someone = "Someone like you";


	//    = "http://upload.wikimedia.org/wikipedia/en/9/9f/Sample_of_%22Another_Day_in_Paradise%22.ogg";
	//    public string url2 = "/Music/leave_a_trace.ogg";

	void Start(){
		//        if (Application.platform == RuntimePlatform.Android) {
		//            print ("Android");
		////            url5 = "http://www.stephaniequinn.com/Music/Pachelbel%20-%20Canon%20in%20D%20Major.mp3";
		//            url6 = "http://www.stephaniequinn.com/Music/Brahms%20Symphony%20-%20from%20Fourth%20Movement.mp3";
		//
		//        } else if (Application.platform == RuntimePlatform.OSXEditor) {
		//            print ("On the mac");
		//            url5 = "http://upload.wikimedia.org/wikipedia/en/4/45/ACDC_-_Back_In_Black-sample.ogg";
		//            url6 = "http://www.stephaniequinn.com/Music/Brahms%20Symphony%20-%20from%20Fourth%20Movement.mp3";
		////            url6 = "http://upload.wikimedia.org/wikipedia/en/9/9f/Sample_of_%22Another_Day_in_Paradise%22.ogg";
		//
		//        } else if (Application.platform == RuntimePlatform.OSXPlayer) {
		//            url5 = "http://upload.wikimedia.org/wikipedia/en/4/45/ACDC_-_Back_In_Black-sample.ogg";
		//            url6 = "http://www.stephaniequinn.com/Music/Brahms%20Symphony%20-%20from%20Fourth%20Movement.mp3";
		//
		////            url6 = "http://upload.wikimedia.org/wikipedia/en/9/9f/Sample_of_%22Another_Day_in_Paradise%22.ogg";
		//
		//        }

		songName = someone;
	}

	public void updateMusic(){
		if (!isLocalPlayer)
			return;
		//        if (Application.platform == RuntimePlatform.Android) {
		//            url6 = newSongMobile;
		//        } else if (Application.platform == RuntimePlatform.OSXEditor) {
		//            url6 = newSongMobile;
		//            print (url6);
		//
		//        } else if (Application.platform == RuntimePlatform.OSXPlayer) {
		//            url6 = newSongMobile;
		//
		//        }

	}

	[ClientRpc]
	public void RpcPlaySong(){
		songName = someone;
		source1 = GetComponent<AudioSource>();
		source1.loop = true;
		source1.clip = Resources.Load(songName) as AudioClip;
		source1.Play ();
	}

	[ServerCallback]
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.N)) 
		{
			RpcPlaySong();
		}

		//        if (Input.GetKeyDown(KeyCode.N)) this.Tune(this.nnurl1);
		//        if (Input.GetKeyDown(KeyCode.M)) this.Tune(this.url3);
		//        if (Input.GetKeyDown(KeyCode.N)) this.Tune(this.url4);
		//        if (Input.GetKeyDown(KeyCode.B)) this.Tune(this.url5);
		//        this.Tune (this.url5);

		//        if (Input.GetKeyDown(KeyCode.B)) this.Tune(this.url2);
	}

	public void Tune(string url)
	{
		//print ("My current url is " + url);
		this.StopAllCoroutines();
		//this.StartCoroutine(this.__Tune(url5));
		//        this.StartCoroutine(this.__Tune("When I was your man"));

		source1 = GetComponent<AudioSource>();
		source1.loop = true;
		source1.clip = Resources.Load(songName) as AudioClip;
		source1.Play ();
	}
	//    IEnumerator __Tune(string url)
	//    {
	////        var www = new WWW(url);
	////
	////        var source = GetComponent<AudioSource>();
	////
	//////        source.clip = www.GetAudioClip (false, false, AudioType.OGGVORBIS);
	////        source.clip = www.GetAudioClip (false, false);
	////
	//////
	////        while (!(source.clip.loadState == AudioDataLoadState.Loaded)) {
	////            yield return null;
	////        }
	////
	////        this.GetComponent<AudioSource>().clip = source.clip;
	////        this.GetComponent<AudioSource>().Play ();
	//    }

}


//public class StreamMusic : MonoBehaviour {
//
//    // Use this for initialization
//    void Start () {
//    
//    }
//    
//    // Update is called once per frame
//    void Update () {
//    
//    }
//}