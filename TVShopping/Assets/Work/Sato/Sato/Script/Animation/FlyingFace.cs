using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FlyingFace : MonoBehaviour {
	//
	//ジョニーの顔を吹っ飛ばすやつです
	//
	ChangeCamera _Camera;
	Easing _Easing;
	CruckAnimator _CruckAnimator;
	WaitFade _WaitFade;
	float _speed = 3.0f;
	[SerializeField]
	float _total_time = 1.0f;
	float _timer;
	Vector3 _defalt_pos;
	Vector3 _move_range;
	Vector3 _target_pos;
	[SerializeField]
	float _fall_range = 10;
	public bool _do_flying_face;
	private bool _do_fall;
	[SerializeField]
	float _fall_time = 3.0f;
	[SerializeField]
	float _fade_start_time = 1.0f;

	// Use this for initialization
	void Start () {

		_Easing = GameObject.FindObjectOfType<Easing> ();
		_Camera = GameObject.FindObjectOfType<ChangeCamera>();
		_CruckAnimator = GameObject.FindObjectOfType<CruckAnimator> ();
		_WaitFade = GameObject.FindObjectOfType<WaitFade> ();
		_do_flying_face = false;
		_do_fall = false;
		_timer = 0.0f;
		_move_range = new Vector3 (30,5,30);
	}

	// Update is called once per frame
	void Update () {

		if (_do_flying_face) {

			//一度だけ通る
			if (_timer == 0.0f) {
				_defalt_pos = transform.position;
				_target_pos = _Camera.CurrentCamera.transform.position;
				Debug.Log (_target_pos);
			}

			_timer += Time.deltaTime;

			transform.position = new Vector3 (
					(float)_Easing.InQuad (_timer, _total_time, _target_pos.x, transform.position.x),
					(float)_Easing.InQuad (_timer, _total_time, _target_pos.y, transform.position.y),
					(float)_Easing.InQuad (_timer, _total_time, _target_pos.z, transform.position.z));
				
		}

		if(_do_fall)
		{
			_timer += Time.deltaTime;

			transform.position = new Vector3 (
				transform.position.x,
				(float)_Easing.InQuad (_timer, _fall_time, _target_pos.y - _fall_range, transform.position.y),
				transform.position.z);

			if (_timer > _fade_start_time) {

				_WaitFade._DoFade = true;

			}

		}


	
	}

	void OnTriggerEnter(Collider other) {
			
		_timer = 0.0f;
		_do_fall = true;
		_do_flying_face = false;
		_CruckAnimator._doCrack = true;
	}

	void Init(){

		_timer = 0.0f;
		_do_fall = false;
		_do_flying_face = false;
		_CruckAnimator._doCrack = false;
		_WaitFade._DoFade = false;


	}
}
