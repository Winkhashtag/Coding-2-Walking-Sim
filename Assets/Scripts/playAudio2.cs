using UnityEngine;

public class playAudio2 : MonoBehaviour
{
    public float fadeTimeInSeconds;

    private AudioSource audio;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        audio = GetComponent<AudioSource>();

       

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();

          //  StartCoroutine(FadeAudio(true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            audio.Stop();
         //   StartCoroutine(FadeAudio(true));
        }
    }
}