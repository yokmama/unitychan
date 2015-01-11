using UnityEngine;
using System.Collections;

public class LevelGenelator : MonoBehaviour {

	public Texture2D tex;
	public GameObject cube, dot;

	// Use this for initialization
	void Start () {
		GameObject level = new GameObject("Level");

		float offw = tex.width * 1.5f / 2; 
		float offh = tex.height * 1.5f / 2 - 3f; 

		for (int x = 0; x < tex.width; x++) {
			for (int y = 0; y < tex.height; y++) {
				if (tex.GetPixel(x, y) != Color.black) {
					GameObject obj = Instantiate(cube, new Vector3(x * 1.5f - offw, 0.5f, y * 1.5f - offh), Quaternion.identity) as GameObject;
					obj.transform.parent = level.transform;
				} else {
					GameObject obj = Instantiate(dot, new Vector3(x * 1.5f - offw, 0.5f, y * 1.5f - offh), Quaternion.identity) as GameObject;
					obj.transform.parent = level.transform;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
