using System;
using System.Collections.Generic;
using UnityEngine;

namespace Match3
{
    public class AudioManager : MonoBehaviour
    {
        public int FXMaxCount = 5;  //最多有多少个音效同时播放

        //AudioClips
        public AudioClip AC_ButtonClick;
        public AudioClip AC_BGM;
        public AudioClip AC_Win;
        public AudioClip AC_Lose;
        public AudioClip AC_Move;
        public AudioClip AC_MoveReverse;
        public AudioClip AC_MoveInValid;
        public AudioClip AC_Match3;
        public AudioClip AC_ClearLine;
        public AudioClip AC_ClearColor;
        public AudioClip AC_Combo;
        public AudioClip AC_GetProp;
        public AudioClip AC_UseProp;
        
        private AudioSource BGMSource;
        private List<AudioSource> FXSources = new List<AudioSource>();
        private int m_currFXSIndex = 0;

        public void Awake()
        {
            BGMSource = this.gameObject.AddComponent<AudioSource>();
            for (int i = 0; i < FXMaxCount; i++)
            {
                AudioSource source = this.gameObject.AddComponent<AudioSource>();
                FXSources.Add(source);
            }
        }

        public void PlayBGM()
        {
            Debug.LogError("PlayBGM");
            BGMSource.clip = AC_BGM;
            BGMSource.loop = true;
            BGMSource.Play();
        }

        public void PlayFXSound(FXSType type, ulong delay = 0, bool loop = false)
        {
            Debug.LogError("PlayFXSound " + type);
            FXSources[m_currFXSIndex].clip = GetAudioClip(type);
            FXSources[m_currFXSIndex].loop = loop;
            FXSources[m_currFXSIndex].Play(delay);
            m_currFXSIndex = ++m_currFXSIndex % FXMaxCount;
        }

        public AudioClip GetAudioClip(FXSType type)
        {
            AudioClip ret = null;
            switch(type)
            {
                case FXSType.ButtonClick:
                    ret = AC_ButtonClick;
                    break;
                case FXSType.BGM:
                    ret = AC_BGM;
                    break;
                case FXSType.Win:
                    ret = AC_Win;
                    break;
                case FXSType.Lose:
                    ret = AC_Lose;
                    break;
                case FXSType.Move:
                    ret = AC_Move;
                    break;
                case FXSType.MoveReverse:
                    ret = AC_MoveReverse;
                    break;
                case FXSType.MoveInValid:
                    ret = AC_MoveInValid;
                    break;
                case FXSType.Match3:
                    ret = AC_Match3;
                    break;
                case FXSType.ClearLine:
                    ret = AC_ClearLine;
                    break;
                case FXSType.ClearColor:
                    ret = AC_ClearColor;
                    break;
                case FXSType.Combo:
                    ret = AC_Combo;
                    break;
                case FXSType.GetProp:
                    ret = AC_GetProp;
                    break;
                case FXSType.UseProp:
                    ret = AC_UseProp;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            return ret;
        }
        
    }
}