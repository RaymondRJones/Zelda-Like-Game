using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	public void Smash () {
		anim.SetBool("smashed",true);
		StartCoroutine(breakCo());

	}
	IEnumerator breakCo(){
		yield return new WaitForSeconds(.3f);
		this.gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
