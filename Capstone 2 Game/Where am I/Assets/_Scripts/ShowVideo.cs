using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ShowVideo : MonoBehaviour {

	public RawImage img;
	public VideoClip videoClip;
	public VideoPlayer videoPlayer;
	public VideoSource videoSource;

	AudioSource audioS;

	// Use this for initialization
	void Start () 
	{
		Application.runInBackground = true;
		StartCoroutine(playVideo());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!videoPlayer.isPlaying) 
		{
			videoPlayer.Play ();
		}
		
	}

	IEnumerator playVideo()
	{
		videoPlayer = gameObject.AddComponent<VideoPlayer> ();
		videoPlayer.playOnAwake = false;

		audioS = gameObject.AddComponent<AudioSource> ();
		audioS.playOnAwake = false;


		audioS.Pause ();

		videoPlayer.source = VideoSource.VideoClip;

		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

		videoPlayer.EnableAudioTrack (0, true);
		videoPlayer.SetTargetAudioSource (0, audioS);

		videoPlayer.clip = videoClip;
		videoPlayer.Prepare ();

		while (!videoPlayer.isPrepared) 
		{
			yield return null;
		}

		Debug.Log ("Finished preparing video");

		img.texture = videoPlayer.texture;

		videoPlayer.Play ();

		audioS.Play ();

		Debug.Log ("Playing video");

		while (videoPlayer.isPlaying) 
		{
			Debug.LogWarning ("Video Time: " + Mathf.FloorToInt ((float)videoPlayer.time));
			yield return null;
		}

		Debug.Log ("Done playing video");



	}
}
