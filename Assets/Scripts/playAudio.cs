using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class playAudio : MonoBehaviour
{

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
            audio.Play ();
        }
    }
}
