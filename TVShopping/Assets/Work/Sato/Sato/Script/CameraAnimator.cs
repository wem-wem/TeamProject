using UnityEngine;
using System.Collections;

public class CameraAnimator : MonoBehaviour {

	enum Animation
	{
		R_HighToCenter,
		L_HighToCenter,
		Zooming,
		Wide,


	}
	Easing _easing;
	float timer;
	Vector2 _center_pos = new Vector2(0.0f,4.5f);


	// Use this for initialization
	void Start () {
		timer = 0;
		_easing = GameObject.FindObjectOfType<Easing>();


	}
	
	// Update is called once per frame
	void Update () {
		//Fix: TEST ベタ打ちアニメーション　のちに直します 
		timer += Time.deltaTime;
		if(timer < 3.0f){
			transform.position = new Vector3((float)_easing.InOutQuart(timer,3.0f,_center_pos.x,transform.position.x),
			(float)_easing.InOutQuart(timer,3.0f,_center_pos.y,transform.position.y),
										 transform.position.z);
		transform.LookAt(GameObject.FindGameObjectWithTag("MainGoods").transform);
		}
	}
}
