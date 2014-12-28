using UnityEngine;
using System.Collections;

/*
 *登録したプレハブを一定間隔で出現させるクラス
 *
 *生成する場所はこれが付いているゲームオブジェクトの位置です。
 */

public class Creator : MonoBehaviour {
	
	//出現させるプレハブ
	public GameObject prefab;
	
	//生成する場所からランダムでどれ位の位置にあるか
	public Vector3 randomPosRange = Vector3.up;
	
	//生成時の速さ
	public Vector3 velocity = Vector3.left;
	
	//初めて生成するまでにかかる時間
	public float offsetTime = 0.0f;
	
	//生成するタイミング
	public float intervalTime = 3.0f;
	
	//生成されたオブジェクトが消えるまでの時間
	public float leftTime = 5.0f;
	
	//このクラスが管理する時間
	private float mTime = 0.0f;
	
	/*
     *初めに呼ばれる関数
     */
	
	void Start () {
		
		//時間をoffsetTime分引いた値にする
		mTime = -offsetTime;
		
	}
	
	/*
     *毎回呼ばれる関数
     */
	
	void Update () {
		/*
		//ゲームの状態がゲーム中でなければ生成しない
		if(Game.instance.state != Game.STATE.MOVE){
			return;
		}
		*/
		
		//フレーム間の時間を足す
		mTime += Time.deltaTime;
		
		/*
         *時間が0以下なら生成しない
         *
         *Start関数で mTimeを-offsetにする
         *mTimeがマイナスの時は動かない
         *毎回mTimeが加算されていき、mTimeが0を超えると動き出す
         */
		
		if(mTime <0.0f){
			return;
		}
		
		//もし、生成する時間になったら
		
		if(mTime >= intervalTime){
			
			//ランダムなポジションを決定する
			
			Vector3 randomPos = Vector3.one;
			
			randomPos.x = Random.Range(-randomPosRange.x,randomPosRange.x);
			
			randomPos.y = Random.Range(-randomPosRange.y,randomPosRange.y);
			
			//今の位置から先程のランダムな位置を足す
			
			Vector3 pos = transform.position + randomPos;
			
			//posにprefabのオブジェクトを生成する
			
			GameObject obj = Instantiate (prefab,pos,transform.rotation) as GameObject;
			
			//決められた速度で動くようにする
			
			obj.GetComponent<Rigidbody2D>().velocity = velocity;
			
			//時間が経つと消えるようにする
			
			Destroy (obj,leftTime);
			
			//時間をリセットする
			
			mTime = 0.0f;
			
		}
		
	}
	
}