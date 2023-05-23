using UnityEngine;
using UnityEngine.Playables;

public class Intro: MonoBehaviour
{

    void Start()
    {
        Invoke("Destroy", 7f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}