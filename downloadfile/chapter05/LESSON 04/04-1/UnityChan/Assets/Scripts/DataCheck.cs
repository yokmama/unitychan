using UnityEngine;
using System.Collections;

public class DataCheck : MonoBehaviour {
	
	System.DateTime now;
	
	int nowMonth;
	int nowDay;
	
	public AudioClip voice_date0101;
	
	private AudioSource univoice;
	
	// Use this for initialization
	void Start () {
		
		//現在の日時を取得
		now = System.DateTime.Now;
		
		nowMonth	= now.Month;
		nowDay		= now.Day;
		
		univoice	= GetComponent<AudioSource> ();
		
		univoice.PlayOneShot(voice_date0101);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
