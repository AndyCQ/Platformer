using UnityEngine.Audio;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
    public static MusicManager instance;


    void Awake()
    {
        if(instance == null){
            instance = this;
        } else{
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds){
            gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start(){
        Play("Start Music");
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }
}
