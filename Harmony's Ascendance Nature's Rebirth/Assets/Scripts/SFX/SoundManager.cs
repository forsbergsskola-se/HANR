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
        public Sound[] sounds;
        public BoolVariable playCombatMusicG;
        public BoolVariable playCombatMusicP;
        public BoolVariable playCombatMusicR;
        public BoolVariable playerWalking;
        public BoolVariable playSlimeMoving;
        public BoolVariable playBossMusic;
        private bool gameMusic;


        private void Awake()
        {
            i = this;
            
            playCombatMusicG.ValueChanged.AddListener(ChangeMusicG);
            playCombatMusicP.ValueChanged.AddListener(ChangeMusicP);
            playCombatMusicR.ValueChanged.AddListener(ChangeMusicR);
            playerWalking.ValueChanged.AddListener(PlayWalkSfx);
            playSlimeMoving.ValueChanged.AddListener(PlaySlimeMove);
            playBossMusic.ValueChanged.AddListener(ChangeBossMusic);

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
            playCombatMusicG.ValueChanged.RemoveListener(ChangeMusicG);
            playCombatMusicP.ValueChanged.RemoveListener(ChangeMusicP);
            playCombatMusicR.ValueChanged.RemoveListener(ChangeMusicR);
            playerWalking.ValueChanged.RemoveListener(PlayWalkSfx);
            playSlimeMoving.ValueChanged.RemoveListener(PlaySlimeMove);
            playBossMusic.ValueChanged.RemoveListener(ChangeBossMusic);
        }
        

        private void Start()
        {
            if (SceneManager.GetActiveScene().name == "Game Scene")
            {
                PlaySound("Game Music");
                gameMusic = true;
            }

            if (SceneManager.GetActiveScene().name == "StartScene")
            {
                PlaySound("Menu Music");
            }    
        }

        private void ChangeMusicG(bool playCombatMusicG)
        {
            if (playCombatMusicG && gameMusic)
            {
                if (playCombatMusicP.getValue() == false 
                    && playCombatMusicR.getValue() == false)
                {
                    StopSound("Game Music");
                    PlaySound("Combat Music");
                    gameMusic = false;
                }
            }

            if (!playCombatMusicG && !gameMusic)
            {
                if (playCombatMusicP.getValue() == false 
                    && playCombatMusicR.getValue() == false)
                {
                    StopSound("Combat Music");
                    PlaySound("Game Music");
                    gameMusic = true;
                }
            }
        }
        
        private void ChangeMusicP(bool playCombatMusicP)
        {
            if (playCombatMusicP && gameMusic)
            {
                if (playCombatMusicG.getValue() == false 
                    && playCombatMusicR.getValue() == false)
                {
                    StopSound("Game Music");
                    PlaySound("Combat Music");
                    gameMusic = false;
                }
            }

            if (!playCombatMusicP && !gameMusic)
            {
                if (playCombatMusicG.getValue() == false 
                    && playCombatMusicR.getValue() == false)
                {
                    StopSound("Combat Music");
                    PlaySound("Game Music");
                    gameMusic = true;
                }
            }
        }
        
        private void ChangeMusicR(bool playCombatMusicR)
        {
            if (playCombatMusicR && gameMusic)
            {
                if (playCombatMusicG.getValue() == false 
                    && playCombatMusicP.getValue() == false)
                {
                    StopSound("Game Music");
                    PlaySound("Combat Music");
                    gameMusic = false;
                }
            }

            if (!playCombatMusicR && !gameMusic)
            {
                if (playCombatMusicG.getValue() == false 
                    && playCombatMusicP.getValue() == false)
                {
                    StopSound("Combat Music");
                    PlaySound("Game Music");
                    gameMusic = true;
                }
            }
        }
        
        private void ChangeBossMusic(bool playBossMusic)
        {
            if (playBossMusic)
            {
                StopSound("Game Music");
                PlaySound("Boss Area Music");
            }
            else
            {
                StopSound("Boss Area Music");
                PlaySound("Game Music");
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
        
        private void PlaySlimeMove(bool PlaylimeMoving) // sound not in sync, removed
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

        private static void StopSound(string soundName)
        {
            Sound sound = i.GetSound(soundName);
            if(sound == null)
                return;
            sound.source.Stop();
        }
    }
}