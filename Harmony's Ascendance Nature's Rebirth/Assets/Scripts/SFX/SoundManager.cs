using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SFX
{
    public class SoundManager : MonoBehaviour
    {
        public float soundVolume = 0.75f;
        static SoundManager i;
        public Sound[] sounds;


        private void Awake()
        {
            i = this;

            foreach (Sound sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.audioClip;
                sound.source.volume = sound.volume * soundVolume;
                sound.source.loop = sound.loop;
            }
        }

        private void Start()
        {
            if (SceneManager.GetActiveScene().name == "Game Scene")
            {
                PlaySound("Game Music");
            }

            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                PlaySound("Menu Music");
            }    
        }
        
        Sound GetSound(string soundName)
        {
            Sound sound = Array.Find(sounds, sound => sound.soundName == soundName);
            Sound soundAlt = Array.Find(sounds, sound => sound.audioClip.name == soundName);

            if (sound != null)
            {
                // sound.source.Stop();
                // sound.source.Play();
                return sound;
            }
            if(soundAlt != null)
            {
                // soundAlt.source.Stop();
                // soundAlt.source.Play();
                return soundAlt;
            }
    
            Debug.Log("Can't Find: " + soundName);
            return null;
        }


        public static void PlaySound(string soundName)
        {
            Sound sound = i.GetSound(soundName);
            
            if(sound == null)
                return;
            sound.source.Stop();
            sound.source.Play();
        }
        
        public static void StopSound(string soundName)
        {
            Sound sound = i.GetSound(soundName);
            if(sound == null)
                return;
            sound.source.Stop();
        }
        
        /*
        public static void SetVolume(string soundName, float volume)
        {
            Sound sound = i.GetSound(soundName);
            if(sound == null)
                return;
            sound.source.volume = volume;
        }*/
    }
}