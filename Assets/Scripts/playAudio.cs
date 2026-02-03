using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent (typeof(AudioSource))]
public class playAudio : MonoBehaviour
{
    public float fadeTimeInSeconds;

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
        if(other.tag == "Player")
        {
            StopAllCoroutines();
            
            StartCoroutine(FadeAudio(true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            StopAllCoroutines();
          
            StartCoroutine(FadeAudio(false));
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
        audio.Play();
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
       

        while (timer < fadeTimeInSeconds)
        {

            //smoothly increase volume from 0 to 1
            //timer / fadeTimeInSeconds represents timer's precentage towards the amount of time we are fading
            // if fadeTime is 2s, and timer is 1s, 1/ 2 = .5 (50% towards 2)
            audio.volume = Mathf.Lerp(1, 0, timer / fadeTimeInSeconds); // 
            timer += Time.deltaTime;
            yield return null; //will wait one frame until timer is greater than fade time
        }

        audio.volume = 0;
        audio.Pause();
    }
}




