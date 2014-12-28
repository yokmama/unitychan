using UnityEngine;
using System.Collections;

/*
 *スコアを表示するGUIにつくクラス
 */

public class ScoreGUI : MonoBehaviour {

	/*
     *初めに呼ばれる関数
     */
	void Start () {
		//はじめにスコアを0にする
		Score.instance.Reset();
	}

	/*
     *毎回呼ばれる関数
     */
	void Update () {
		
		//Scoreクラスからscoreの情報を得る
		int score = Score.instance.score;
		
		//5桁になるように0を足す
		string scoreAddZero = score.ToString("00000");
		
		//テキストをGUIで表示する
		GetComponent<GUIText>().text = "Score : " + scoreAddZero;
	}
}