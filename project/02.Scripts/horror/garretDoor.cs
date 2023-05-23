using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garretDoor : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Open(horrorPlayer player)
    {
        StartCoroutine(RotateDoor(player));
    }
    public IEnumerator RotateDoor(horrorPlayer player)
    {
        audioSource.Play();
        for (int i = 0; i < 80; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(0, 1, 0);
        }
        player.StartMissionOther("Mission2", "1층으로 내려가는\n계단을 찾아라.");
    }
}