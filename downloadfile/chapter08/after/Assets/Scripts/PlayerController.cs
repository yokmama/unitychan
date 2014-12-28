using UnityEngine;
using System.Collections;

/*
 *Playerクラス
 *
 *UnityChan2DController以外のことを制御する
 *
 */

public class PlayerController : MonoBehaviour {
	public AudioClip jumpVoice; //ジャンプをする時のボイス
	public AudioClip damageVoice; //ダメージを受けた時のボイス

	UnityChan2DController mUnityChan2DController; //UnityChan2DControllerのコンポーネント

	/*
	 * 初めに呼ばれる関数
	 */
	void Start(){
		//UnityChan2DControllerのコンポーネントを取得しておく
		mUnityChan2DController = GetComponent<UnityChan2DController> ();
	}

	/*
	 * ダメージを受けた時に呼ばれる関数
	 */
	void OnDamage(){	
		//声を出す
		PlayerVoice(damageVoice);

		//あたり判定を消す
		GetComponent<Collider2D>().enabled = false;
		//UnityChan2Dを動けないようにする
		mUnityChan2DController.enabled = false;

		//ゲーム遷移をゲームオーバーにする
		Game.instance.state = Game.STATE.GAMEOVER;
	}
	
	/*
	 * ジャンプするときに呼ばれる関数
	 */
	void Jump(){	
		//声を出す
		PlayerVoice(jumpVoice);
	}
	
	/*
	 * 声を出すときに呼ばれる関数
	 * (声は同時に2音以上鳴らないので、今流れてる音を消してから再生する。)
	 */
	void PlayerVoice(AudioClip clip){
		//音を消す
		GetComponent<AudioSource>().Stop();
		
		//音を再生する
		GetComponent<AudioSource>().PlayOneShot (clip);
		
	}
}