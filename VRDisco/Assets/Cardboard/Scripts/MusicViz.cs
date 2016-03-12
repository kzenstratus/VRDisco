using UnityEngine;
using System.Collections;

public class MusicViz : MonoBehaviour {


	public GameObject bar;
	public int numberObjects = 15;
	public float radius = 5f;
	public GameObject[] cubes;

	// Use this for initialization
	void Start () {
		for(int i = 1; i< numberObjects; i ++){
			float angle = i * Mathf.PI * 2 /numberObjects;
			Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)+0.3f,1) * radius;
			Instantiate(bar,pos, Quaternion.identity);
		}
		cubes = GameObject.FindGameObjectsWithTag ("musicviz");
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = new float[1024];
		int channel = 0;
		float amp = 0f;
		AudioListener.GetOutputData(spectrum,channel);
		for(int i = 0; i < numberObjects; i++) {
			Vector3 previousScale = cubes[i].transform.localScale;
			amp = Mathf.Pow (spectrum [i]*10f, 2f)/10f;

			previousScale.x = Mathf.Lerp(previousScale.x, amp,Time.deltaTime * 30);
			cubes[i].transform.localScale = previousScale;

		}

	}
}
