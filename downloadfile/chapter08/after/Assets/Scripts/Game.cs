using UnityEngine;
using System.Collections;

/*
 *ゲームの遷移を管理するクラス
  */

public class Game : MonoBehaviour {
	
	// Gameクラスの唯一のインスタンス
	private static Game mInstance;
	
	/*Gameのインスタンスを返すパブリックな関数
     *(staticでpublicなので、どのソースコードからでも呼ぶことができる)
     */
	public static Game instance{
		get{
			//インスタンスが参照されているか
			if(mInstance == null){
				//インスタンスを探し、参照する
				mInstance = FindObjectOfType<Game>();
			}
			//インスタンスを返す
			return mInstance;
		}
	}
	
	//ゲームの状態
	public enum STATE{
		NONE,        //何もない状態
		START,        //スタートの状態
		MOVE,        //ゲーム中の状態
		GAMEOVER    //ゲームオーバーの状態
	};
	
	//ゲームの状態
	public STATE state;
	
	/*
     *はじめに呼ばれる関数
     */
	void Start () {	
		//ゲームの状態をスタートに
		state = STATE.START;
		//StartCountDownを呼び出す
		
		StartCoroutine("StartCountDown");
	}
	
	/*
     *毎回呼ばれる関数
     */
	
	void Update () {
		
		switch(state){
		case STATE.START:
			break;
		case STATE.MOVE:
			break;
		case STATE.GAMEOVER:
			//GUIにGame Overと表示する
			GetComponent<GUIText>().text = "Game Over";
			//もし、Jumpボタンが押されたら
			if(Input.GetButtonDown ("Jump")){
				//今いるシーン				
				int currentScene = Application.loadedLevel;
				//今いるシーンをもう一度最初から呼び出す
				Application.LoadLevel (currentScene);
			}
			break;
		}
	}
	
	IEnumerator StartCountDown(){
		
		//GUIの表示を3にする
		
		GetComponent<GUIText>().text = "3";
		
		//1秒待つ
		
		yield return new WaitForSeconds(1.0f);
		
		//GUIの表示を3にする
		
		GetComponent<GUIText>().text = "2";
		
		//1秒待つ
		
		yield return new WaitForSeconds(1.0f);
		
		//GUIの表示を3にする
		
		GetComponent<GUIText>().text = "1";
		
		//1秒待つ
		
		yield return new WaitForSeconds(1.0f);
		
		//GUIに何も表示しない
		
		GetComponent<GUIText>().text = "";
		
		//ゲームの状態をゲーム中にする
		
		state = STATE.MOVE;
		
	}
	
}