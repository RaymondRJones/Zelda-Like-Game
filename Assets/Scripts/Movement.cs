using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
	walk,
	attack,
	interact
}

public class Movement : MonoBehaviour {
	public PlayerState currentState;
	public float speed;
	private Rigidbody2D myRigidbody;
	private Vector3 change;
	private Animator animator;
	// Use this for initialization
	void Start () {
		//Gets rigidbody of selected component
		myRigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		change = Vector3.zero;
		change.x = Input.GetAxisRaw("Horizontal");
		change.y = Input.GetAxisRaw("Vertical");

		if(Input.GetButtonDown("attack") && currentState != PlayerState.attack){
			StartCoroutine(AttackCo());
		}
		if( currentState == PlayerState.walk){
			updateAnimationAndMove();
		}
	}
	public IEnumerator AttackCo(){
		animator.SetBool("attacking",true);
		currentState = PlayerState.attack;
		yield return null;
		animator.SetBool("attacking",false);
		yield return new WaitForSeconds(.3f);
		currentState = PlayerState.walk;

	}
	void updateAnimationAndMove(){
		if(change != Vector3.zero){
			moveCharacter();
			animator.SetFloat("moveX",change.x);
			animator.SetFloat("moveY",change.y);
			animator.SetBool("moving",true);
		}
		else{
			animator.SetBool("moving",false);

		}
	}
	void moveCharacter(){
		myRigidbody.MovePosition(
			transform.position + change * speed * Time.deltaTime
		);
	}
}
