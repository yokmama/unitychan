using UnityEngine;
using System.Collections;

/*
 * スコアを管理するクラス
 */

public class Score : MonoBehaviour {
	
	// Scoreクラスのインスタンス
	private static Score mInstance; 
	/*
     *Scoreのインスタンスを返す関数
     *(staticでpublicなので、どのソースコードからでも呼ぶことができる)
     */
	public static Score instance{	
		get{
			//インスタンスが参照されているか
			if(mInstance == null){	
				//インスタンスを探し、参照する
				mInstance = FindObjectOfType<Score>();
			}
			//インスタンスを返す
			return mInstance;
		}
	}

	//スコア
	public int score{
		get;
		//setはこのソースコードからしか呼ばれないようにする
		private set;
	}
	
	/*
     *スコアに1を足す関数
     */
	public void Add(){	
		score++;
	}
	
	/*
     *スコアを0にする関数
     */
	
	public void Reset(){
		score = 0;	
	}
}