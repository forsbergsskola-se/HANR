using System;
using CustomObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace SFX
{
    public class SoundManager : MonoBehaviour
    {
        public float soundVolume = 0.75f;
        static SoundManager i;
        public Sound[] sounds;
        public BoolVariable playCombatMusic;
        public BoolVariable playerWalking;
        public BoolVariable playSlimeMoving;


        private void Awake()
        {
            i = this;
            
            playCombatMusic.ValueChanged.AddListener(ChangeMusic);
            playerWalking.ValueChanged.AddListener(PlayWalkSfx);
            playSlimeMoving.ValueChanged.AddListener(PlaySlimeMove);

            foreach (Sound sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.audioClip;
                sound.source.volume = sound.volume * soundVolume;
                sound.source.loop = sound.loop;
            }
        }

       


        private void OnDestroy()
        {
            playCombatMusic.ValueChanged.RemoveListener(ChangeMusic);
            playerWalking.ValueChanged.RemoveListener(PlayWalkSfx);
            playSlimeMoving.ValueChanged.RemoveListener(PlaySlimeMove);
        }
        

        private void Start()
        {
            if (SceneManager.GetActiveScene().name == "Game Scene" || SceneManager.GetActiveScene().name == "Game Scene 1")
            {
                PlaySound("Game Music");
            }

            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                PlaySound("Menu Music");
            }    
        }
        
        private void ChangeMusic(bool playCombatMusic)
        {
            if (playCombatMusic)
            {
                StopSound("Game Music");
                PlaySound("Combat Music");
                Debug.Log("Change Music");
            }
            else
            {
                StopSound("Combat Music");
                PlaySound("Game Music");
                Debug.Log("Change back");
            }
        }
        
        private void PlayWalkSfx(bool playerWalking)
        {
            if (playerWalking)
            {
                PlaySound("Walking");
            }
            else
            {
                StopSound("Walking");
            }
        }
        
        private void PlaySlimeMove(bool PlaylimeMoving)
        {
            if (playSlimeMoving)
            {
                PlaySound("Slime Moving");
            }
            else
            {
                StopSound("Slime Moving");
            }
        }
        
        Sound GetSound(string soundName)
        {
            Sound sound = Array.Find(sounds, sound => sound.soundName == soundName);
            Sound soundAlt = Array.Find(sounds, sound => sound.audioClip.name == soundName);

            if (sound != null)
            {
                return sound;
            }
            if(soundAlt != null)
            {
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