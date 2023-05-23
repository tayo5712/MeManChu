using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Run_epilogue : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public TimelineAsset timeline;

    private void OnTriggerEnter(Collider other)
    {
        Play();
    }
    public void Play()
    {
        playableDirector.Play();
    }

    public void PlayFromTimeline()
    {
        playableDirector.Play(timeline);
    }
}
