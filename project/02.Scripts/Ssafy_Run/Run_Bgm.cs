using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Run_Bgm : MonoBehaviour
{

    public AudioClip[] Music = new AudioClip[4]; // 사용할 BGM
    public AudioSource AS;
    public int track = 0;
    public bool check = true;
    private TextMeshProUGUI title;
    private TextMeshProUGUI song;

    void Awake()
    {
        AS = this.GetComponent<AudioSource>();
        title = GameObject.Find("Title").GetComponent<TextMeshProUGUI>();
        song = GameObject.Find("Song").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!AS.isPlaying && track == 0 && check == true)
        {
            AS.clip = Music[track];
            AS.Play();
            track = 1;
            title.text = "Turtleneck";
        }
        else if (!AS.isPlaying && track == 1 && check == true)
        {
            AS.clip = Music[track];
            AS.Play();
            track = 2;
            title.text = "End of the Rainbow";
        }
        else if (!AS.isPlaying && track == 2 && check == true)
        {
            AS.clip = Music[track];
            AS.Play();
            track = 3;
            title.text = "Young Squire";
        }
        else if (!AS.isPlaying && track == 3 && check == true)
        {
            AS.clip = Music[track];
            AS.Play();
            track = 0;
            title.text = "KnockOut";
        }
        if (check == true)
        {
            song.text = "노래 끄기";
        }
        else
        {
            song.text = "노래 켜기";
        }
    }
}