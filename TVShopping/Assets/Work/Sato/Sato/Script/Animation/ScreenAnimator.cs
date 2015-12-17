using UnityEngine;
using System.Collections;

public class ScreenAnimator : MonoBehaviour {

	Easing _Easing;
	[SerializeField]
	bool _open_screen_animation = false;
	[SerializeField]
	bool _close_screen_animation = false;
	[SerializeField]
	float _add_range = -5.0f;
	[SerializeField]
	float _total_time = 3.0f;
	float _timer = 0;
	float _defalt_pos;
	// Use this for initialization
	void Start () {
		_defalt_pos = transform.position.y;
		_Easing = GameObject.FindObjectOfType<Easing> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (_open_screen_animation) {
			_timer += Time.deltaTime;
			transform.position = new Vector3 (transform.position.x,
				(float)_Easing.OutBounce (
					_timer,
					_total_time,
					_defalt_pos + _add_range,
					_defalt_pos), transform.position.z);
		
			if (_timer >= _total_time) {

				_timer = 0;
				_open_screen_animation = false;
			}
		} 

		if (_close_screen_animation) {
			_timer += Time.deltaTime;
			transform.position = new Vector3 (transform.position.x,
				(float)_Easing.OutBounce (
					_timer,
					_total_time,
					_defalt_pos,
					_defalt_pos + _add_range), transform.position.z);

			if (_timer >= _total_time) {

				_close_screen_animation = false;
				_timer = 0;
			
			}
		} 
	}
}
