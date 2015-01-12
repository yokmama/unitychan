using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	public AudioClip voice_01;
	public AudioClip voice_02;
	
	private Animator animator;
	
	private AudioSource univoice;
	
	// Use this for initialization
	void Start () {
	
		animator	= GetComponent<Animator> ();
		
		univoice	= GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		animator.SetBool("Touch", false);
		
		Ray ray;
		RaycastHit hit;
		
		if( Input.GetMouseButtonDown(0) ){
	  
			//マウスカーソルの位置からカメラの画面を通してレイを飛ばす
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray,out hit, 100)) {
				
				Debug.Log("hit");
				
				
				animator.SetBool("Touch", true);
				
				univoice.clip = voice_02;
				univoice.Play();
				
			}
			
		}
	}
}
