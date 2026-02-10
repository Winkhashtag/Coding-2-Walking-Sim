using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent (typeof(AudioSource))]
public class playAudio : MonoBehaviour
{
    public float fadeTimeInSeconds;

    public bool playOnce = false;
    private bool hasInteracted = false;

    private AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        audio = GetComponent<AudioSource> ();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(playOnce &&  hasInteracted)
            return;

        if(other.tag == "Player")
        {
            StopAllCoroutines();
            hasInteracted = true;
            StartCoroutine(FadeAudio(true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            StopAllCoroutines();
            
            StartCoroutine(FadeAudioOut(true));
           
        }
    }

    private IEnumerator FadeAudio(bool fadeIn)
    {
        float timer = 0;
        //if fadeIn is true set to 0, else set to 1
        float start = fadeIn ? 0 : audio.volume;
        //if fadeIn is true set to 1, else set to 0
        float end = fadeIn ? 1 : 0;

        if (fadeIn) audio.Play();
        
        while (timer < fadeTimeInSeconds)
        {
            audio.volume = Mathf.Lerp(start, end, timer / fadeTimeInSeconds); // 
            timer += Time.deltaTime;
            yield return null; //will wait one frame until timer is greater than fade time
        }

        audio.volume = 1;
    }


    private IEnumerator FadeAudioOut(bool fadeOut)
    {
        float timer = 0;
        //if fadeIn is true set to 0, else set to 1
        float start = fadeOut ? audio.volume : 0;
        //if fadeIn is true set to 1, else set to 0
        float end = fadeOut ? 0 : 1;

        if (fadeOut)

        while (timer < fadeTimeInSeconds)
        {
            audio.volume = Mathf.Lerp(start, end, timer / fadeTimeInSeconds); // 
            timer += Time.deltaTime;
            yield return null; //will wait one frame until timer is greater than fade time
        }

        audio.volume = 0;
    }
}




