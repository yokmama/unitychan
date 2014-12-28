using UnityEngine;
using System.Collections;
/*
 *コインのクラス
 */
public class Coin : MonoBehaviour {

	//トリガーが接触した時に一度呼ばれる
	void OnTriggerEnter2D(Collider2D other){
		
		//もし、接触したオブジェクトのタグが"Player"なら
		if(other.tag == "Player"){
			//スコアをたす
			Score.instance.Add();

			//描画を消す			
			GetComponent<Renderer>().enabled = false;

			//当たりを消す			
			GetComponent<Collider2D>().enabled = false;
			
			//音を再生する
			GetComponent<AudioSource>().Play ();
			
			//audioの再生する時間の後にオブジェクトを消す
			Destroy (gameObject,GetComponent<AudioSource>().clip.length);
			
		}
		
	}
	
}