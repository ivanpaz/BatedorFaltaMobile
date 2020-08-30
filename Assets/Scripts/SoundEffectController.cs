using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectController : MonoBehaviour
{
    public static SoundEffectController metod;
    [SerializeField] private AudioSource source;

    private AudioClip actualAudio;
    private AudioInstance audioInstance;

    private void Awake()
    {
        if(metod == null)
        {
            metod = this;
            DontDestroyOnLoad(metod);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySong (AudioClip audio){
        
        if(audioInstance != null){
            audioInstance.setAudio(audio);
        }else{
            audioInstance = new AudioInstance(0, 100, audio);
        }

        source.clip = audioInstance.getAudio();
        source.Play();
    }

    public void PlaySong (int id, AudioClip audio){
        bool canPlay = false;
        if(audioInstance != null){
            audioInstance.setAudio(audio);
        }else{
            audioInstance = new AudioInstance(id, 100, audio);
        }

        if(!audioInstance.idIsEqual(id)){
            source.clip = audioInstance.getAudio();
            canPlay = true;
        }

        if(canPlay)
            source.Play();
    }

    public void PlaySong (int id, int priority, AudioClip audio){

        bool canPlay = false;
        if(audioInstance != null){
            if(getIsPlaying()){
                if(!audioInstance.idIsEqual(id)){
                    if(audioHasPriority(audioInstance.getPriority(), priority)){
                        audioInstance.setAudio(audio);
                        audioInstance.setPriority(priority);
                        canPlay = true;
                    }
                }
            }else{
                audioInstance.setAudio(audio);
                audioInstance.setPriority(priority);
                canPlay = true;
            }
            
        } else{
            audioInstance = new AudioInstance(id, priority, audio);
            canPlay = true;
        }

        if(canPlay){
            source.clip = audioInstance.getAudio();
            source.Play();
        }
    }

     public void PlaySong (AudioClip audio, int priority){

        bool canPlay = false;
        if(audioInstance != null){
            if(getIsPlaying()){
                if(audioHasPriority(audioInstance.getPriority(), priority)){
                    audioInstance.setAudio(audio);
                    audioInstance.setPriority(priority);
                    canPlay = true;
                }
            }else{
                audioInstance.setAudio(audio);
                audioInstance.setPriority(priority);
                canPlay = true;
            }
            
        } else{
            audioInstance = new AudioInstance(0, priority, audio);
            canPlay = true;
        }

        if(canPlay){
            source.clip = audioInstance.getAudio();
            source.Play();
        }
    }

    bool getIsPlaying (){
        return source.isPlaying;
    }

    AudioClip getAudioByPriority (AudioInstance oldInstance, AudioInstance newInstance){
        AudioClip result;

        int firtPriority = oldInstance.getPriority();
        int secondPriority = newInstance.getPriority();

        if(firtPriority > secondPriority){
            result = oldInstance.getAudio();
        }else {
            result = newInstance.getAudio();
        }

        return result;
    }

    bool audioHasPriority (int oldInstance, int newInstance){
        bool result;
        if(oldInstance > newInstance){
            result = false;
        }else {
            result = true;
        }

        return result;
    }

    class AudioInstance {
        int id = 0;
        int priority = 100;
        AudioClip audio;

        public AudioInstance(int id, int priority, AudioClip audio){
            this.id = id;
            this.priority = priority;
            this.audio = audio;
        }

        public AudioClip getAudio (){
            return this.audio;
        }

        public void setAudio (AudioClip audio){
            this.audio = audio;
        }

        public int getPriority (){
            return this.priority;
        }

        public void setPriority (int priority){
            this.priority = priority;
        }

        public bool idIsEqual (int id){
            return id == this.id;
        }
    }
}
