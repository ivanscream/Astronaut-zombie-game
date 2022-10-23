using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator anim;
		private Rigidbody rb;
		public float speed = 10.0f, turnSpeed = 150.0f, jumpForce = 10f;
		private float moveDirection;
		private AudioSource steps;
		public AudioSource jumpSound;

		void Start () {
			rb = GetComponent <Rigidbody>();
			anim = gameObject.GetComponentInChildren<Animator>();
			steps = GetComponent<AudioSource>();
		}

		void Update (){
			if(!PlayerHealth.death) {
				if (Input.GetKey (KeyCode.W)) {
					anim.SetInteger ("AnimationPar", 1);

					if(!steps.isPlaying)
						steps.Play();

				} else {

					if(steps.isPlaying)
						steps.Pause();

					anim.SetInteger ("AnimationPar", 0);
				}

				if (rb.velocity.y <= 0.1f)
					anim.SetBool("isJump", false);

				if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0) {
					rb.AddForce(Vector3.up * jumpForce);
					anim.SetTrigger("Jumping");
					anim.SetBool("isJump", true);
					jumpSound.Play();
				}
			

				moveDirection = Input.GetAxis("Vertical") * speed * Time.deltaTime;
				rb.MovePosition(transform.position + transform.forward * moveDirection);
				float turn = Input.GetAxis("Horizontal");
				transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			}
		}
}
