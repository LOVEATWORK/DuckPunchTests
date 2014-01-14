using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	private Animator animator;

	public Transform playerReachStart, playerReachEnd;

	public KeyCode duck;
	public KeyCode punch;
	public AudioClip punchSound;
	public AudioClip duckSound;

	public bool hit = false;
	public bool punching = false;
	public bool ducking = false;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
		PlayerMovement ();
		Raycasting ();
	}

	void PlayerMovement() 
	{

		if (Input.GetKeyDown (duck)) {
			ducking = true;
			animator.CrossFade ("Duck", 1f);
			audio.PlayOneShot(duckSound);
			// If opponent is ducking, punch shouldn't hit.

		} else if (Input.GetKeyDown (punch)) {
			punching = true;
			animator.CrossFade ("Punch", 1f);
			audio.PlayOneShot(punchSound);
		} else {
			punching = false;
			ducking = false;
			animator.SetInteger("Action", 0);		
		}
	}

	void Raycasting() 
	{
		Debug.DrawLine (playerReachStart.position, playerReachEnd.position, Color.white);
		hit = Physics2D.Linecast (playerReachStart.position, playerReachEnd.position);

		Debug.Log (hit);

		if (punching == true && hit == true && ducking != true) 
		{
			Debug.Log("You punched him!!");
		}

	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log (col);
	}
}
