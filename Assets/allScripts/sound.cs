﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class sound 
{
    public AudioClip clip;
    public  string   namee;
    [Range(0f,1f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;
   public bool loop;
    [HideInInspector]
    public AudioSource source;

}
