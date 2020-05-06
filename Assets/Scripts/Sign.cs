using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour {

	public GameObject dialogBox;
	public Text dialogText;
	public string dialog;
	public bool playerInRage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && playerInRage){
			if(dialogBox.activeInHierarchy){
				dialogBox.SetActive(false);
			}
			else{
				dialogText.text = dialog;
				dialogBox.SetActive(true);

			}
		}

	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			playerInRage = true;

		}
	}
	void OnTriggerExit2D(Collider2D other){
	if(other.CompareTag("Player")){
			playerInRage = false;		
			dialogBox.SetActive(false);
	}
}
}
