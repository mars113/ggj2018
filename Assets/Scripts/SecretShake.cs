﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretShake : MonoBehaviour 
{
	[SerializeField]
	Vector3 shakeAttr = new Vector3 (0, 0.1f, 0);

	[SerializeField]
	float speed = 50.0f;

	AudioSource audio;

	void Awake(){
		this.audio = this.GetComponent<AudioSource> ();
	}

	void OnEnable(){
		if (this.audio != null) {
			this.audio.Play ();
		}
	}

	void OnDisable(){
		if (this.audio != null) {
			this.audio.Stop ();
		}
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		this.transform.position += shakeAttr * Mathf.Sin(Time.time * speed);
	}
}
