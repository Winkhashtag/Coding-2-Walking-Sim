using UnityEngine;
using UnityEngine.Audio;

public class playAudio2 : MonoBehaviour
{
    public AudioMixerSnapshot unmutedSnapshot;
    public AudioMixerSnapshot mutedSnapshot;
    public float fadeTime;

    private AudioSource audio;
    private AudioMixer mixer;
    private float[] weights;
    private AudioMixerSnapshot[] snapshots;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        audio = GetComponent<AudioSource>();
        mixer = audio.outputAudioMixerGroup.audioMixer;

        snapshots = new AudioMixerSnapshot[]
        {
            unmutedSnapshot, //index 0
            mutedSnapshot // index 1
        };
        //make an array of size 2
        weights = new float[2];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            weights[0] = 1;  //turn muted snapshot ON
            weights[1] = 0;  //turn muted snapshot OFF
            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            weights[0] = 0;  //turned unmuted OFF
            weights[1] = 1;  // turn unmuted ON
            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);

        }
    }
}