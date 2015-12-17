using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaitFade : MonoBehaviour {

	Easing _Easing;
	[SerializeField]
	float _fade_total_time = 1.0f;
	float _timer = 0;
	[SerializeField]
	Image[] _fade_image;
	[SerializeField]
	Text _text;
	float alfa = 0.0f;
	[SerializeField]
	bool _do_fade;
	public bool _DoFade
	{
		get{ return _do_fade;}
		set{_do_fade = value; }
	}
	// Use this for initialization
	void Start () {
		alfa = 0.0f;
		_timer = 0.0f;
		_Easing = GameObject.FindObjectOfType<Easing> ();
		foreach (var image in _fade_image) {

			image.color = new Color (1,1,1,alfa);
 		
		}
		_text.color =  new Color (1,1,1,alfa);
	}
	
	// Update is called once per frame
	void Update () {
	

		if (_do_fade) {
			_timer += Time.deltaTime;

			alfa = (float)_Easing.InQuad(_timer,_fade_total_time,1,alfa);
			foreach (var image in _fade_image) {

				image.color = new Color (1, 1, 1, alfa);

			}
			_text.color = new Color (0, 0, 0, alfa);
		}
	}
}
