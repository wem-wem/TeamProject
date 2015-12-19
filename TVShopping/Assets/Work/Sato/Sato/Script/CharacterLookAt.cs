using UnityEngine;
using System.Collections;

public class CharacterLookAt : MonoBehaviour {

	ChangeCamera _target_camera;
	Vector3 _direction;
	// Use this for initialization
	void Start () {
		_target_camera = GameObject.FindObjectOfType<ChangeCamera>();
		/*_direction = new Vector3 (
			_target_camera.CurrentCamera.transform.position.x - transform.position.x,
			_target_camera.CurrentCamera.transform.position.y - transform.position.y,
			_target_camera.CurrentCamera.transform.position.z - transform.position.z);
		_direction.Normalize ();
		transform.rotation = Quaternion.FromToRotation (Vector3.back,_target_camera.CurrentCamera.transform.position);
		*/
		Vector3 target = -_target_camera.CurrentCamera.transform.position;
		target.y = transform.position.y;
		this.transform.LookAt(target);  
	
	}


	// Update is called once per frame
	void Update () {

		/*_direction = new Vector3 (
			_target_camera.CurrentCamera.transform.position.x - transform.position.x,
			_target_camera.CurrentCamera.transform.position.y - transform.position.y,
			_target_camera.CurrentCamera.transform.position.z - transform.position.z);
		_direction.Normalize ();
		transform.rotation = Quaternion.FromToRotation (Vector3.back,_target_camera.CurrentCamera.transform.position);
		*/
		Vector3 target = -_target_camera.CurrentCamera.transform.position;
		target.y = transform.position.y;
		this.transform.LookAt(target);  
	
	}
}
