using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;



public class carController : MonoBehaviour {

	Animator anim;
    new AudioSource audio;
	VideoPlayer vid;

	//public GameObject v;

 	public static carController instance;
	//public GameObject car;
	


	//Create a cloned object so we can access the functions
	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {


		

		//Loop through the child items activating the correct item by name
		for (int i = 0; i < transform.childCount; ++i)
		{

			//Check the current selected item and activate
			if (transform.GetChild(i).gameObject.name == gameController.currentCarSelected)
			{
				transform.GetChild(i).gameObject.SetActive(true);
				

				//Get the animator componant from the active item
				anim = transform.GetChild(i).gameObject.GetComponent<Animator>();
			}
			else
			{
				//Deactivate all other cars
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}

	}
	



	//Called from _Handle
	public void triggerAnimation(string action)
	{
		anim = GameObject.Find(gameController.currentCarSelected).GetComponent<Animator>();
		anim.SetTrigger(action);
	}

	//Called from _Handle
	public void showMessage()
	{
		//TODO
	}

	public void playSound()
	{
		audio = GameObject.Find(gameController.currentCarSelected).GetComponent<AudioSource>();
		audio.Play();
	}

	public void stopSound()
	{
		audio = GameObject.Find(gameController.currentCarSelected).GetComponent<AudioSource>();
		audio.Stop();
	}

	public void playVideo()
	{
		vid = GameObject.Find(gameController.currentCarSelected + "/video/").GetComponent<VideoPlayer>();
		vid.Play();
		
	}

	public void stopVideo()
	{
		vid = GameObject.Find(gameController.currentCarSelected + "/video/").GetComponent<VideoPlayer>();
		vid.Stop();
	}





}

