using UnityEngine;
using System.Collections;

public class Musicplayer : MonoBehaviour {
	
	public AudioClip MusicToPlay;
	
	void Start()
	{
		audio.loop = true;
		audio.clip = MusicToPlay;
		audio.Play();
	}
}
