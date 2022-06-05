using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour
{
	private CapsuleCollider capsuleCollider;
	private Rigidbody rb;

	public float acceleration;

	private float currentSpeed;


	//public Transform followCamera;
	public WheelJoint2D wheel1;
	public WheelJoint2D wheel2;

	[SerializeField]
	public TextMeshProUGUI game_end_score;
	[SerializeField]
	public Button restartButton;
	[SerializeField]
	public TextMeshProUGUI game_end_distance;

	[HideInInspector]
	public float horizontalInput = 0;

	[SerializeField]
	private Transform SpawnPosition;

	[SerializeField]
	private Text fuelMeter;
	private float fuel = 100;


	[SerializeField]
	private Text coinCounter;
	private int score = 0;

	[SerializeField]
	private Text distanceCounter;


	public Transform followCamera;

	// Start is called before the first frame update
	void Start()
	{
		capsuleCollider = GetComponent<CapsuleCollider>();
		rb = GetComponent<Rigidbody>();
		currentSpeed = 0.0f;
	}

	// Update is called once per frame
	void Update()
	{
		float horizontalInput = 0.0f;
		if (fuel <= 0)
		{
			game_end_distance.gameObject.SetActive(true);
			game_end_score.gameObject.SetActive(true);
			restartButton.gameObject.SetActive(true);
			coinCounter.gameObject.SetActive(false);
			distanceCounter.gameObject.SetActive(false);
			fuelMeter.gameObject.SetActive(false);
			acceleration = 0.0f;
		}
		else
		{
			horizontalInput = Input.GetAxis("Horizontal");
		}

		fuel -= 0.008f;
		fuelMeter.text = "Fuel : %" + ((int)fuel).ToString();



		float distance = transform.position.x - (-22.33f);
		distanceCounter.text = "Distance : " + ((int)distance).ToString();

		game_end_distance.text = "Total Distance : " + ((int)distance).ToString();

		coinCounter.text = "Collected Coin : " + ((int)score).ToString();
		game_end_score.text = "Collected Coin : " + ((int)score).ToString();

		if (horizontalInput == 0.0f)
		{
			if (currentSpeed >= 0)
			{
				currentSpeed -= acceleration;
			}
			else
			{
				currentSpeed += acceleration;

			}
		}
		else {
			currentSpeed += acceleration * horizontalInput;
		}
		transform.position = SpawnPosition.position;
		followCamera.position = new Vector3(SpawnPosition.position.x, SpawnPosition.position.y, followCamera.position.z);

	}

	public void Move()
	{

		if (currentSpeed >= 1500)
        {
			currentSpeed = 1500;

		}

		if (currentSpeed <= -1000)
		{
			currentSpeed = -1000;

		}

		wheel1.useMotor = true;
		wheel2.useMotor = true;
		JointMotor2D motorr = new JointMotor2D();
		motorr.motorSpeed = currentSpeed;
		motorr.maxMotorTorque = 10000;
		wheel1.motor = motorr;
		wheel2.motor = motorr;

		Vector3 movedir = new Vector3(horizontalInput, 0);

	}

	//converts velocity vector to 2D, then gets its x, which is actually x and z velocities added together.
	public float GetVerticalVelocity()
	{
		return rb.velocity.y;
	}

	public bool IsDPressed()
    {
		return Input.GetKey(KeyCode.D);
    }
	public bool IsAPressed()
	{
		return Input.GetKey(KeyCode.A);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("OnCollisionEnter2D");
		if (col.gameObject.tag == "gas") 
		{
			fuel += 40.0f;
			if(fuel >= 100.0f)
            {
				fuel = 100.0f;
            }
			Destroy(col.gameObject,0.01f);
		}
		if (col.gameObject.tag == "coin")
		{
			score += 1;
			Destroy(col.gameObject,0.01f);
		}

	}

}
