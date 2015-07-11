using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public float power;
	public float turnPower;
	private Rigidbody2D rigidbody2D;
	
	void Start() {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {

		float accel = Input.GetAxis ("Vertical");
		float steer = Input.GetAxis ("Horizontal");

		float rot = transform.localEulerAngles.z - steer * turnPower;
		transform.localEulerAngles = new Vector3 (0, 0, rot);

//		rigidbody2D.AddTorque (steer * turnPower);
		rigidbody2D.AddForce (transform.up * -accel * power);



		killOrthogonalVelocity ();
	}

	void killOrthogonalVelocity() {
		Vector2 forwardVelocity = -transform.forward * Vector2.Dot (rigidbody2D.velocity, transform.forward);
		Vector2 rightVelocity = -transform.right * Vector2.Dot (rigidbody2D.velocity, transform.right);
		rigidbody2D.velocity = forwardVelocity + rightVelocity * 0.8f;
	}
}