using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class audiomanager : MonoBehaviour
{
    public sound[] soundsarray;
    
    
    private void Awake()
    {
        for (int i = 0; i < soundsarray.Length; i++)
        {
          
            soundsarray[i].source =  gameObject.AddComponent<AudioSource>();
            soundsarray[i].source.playOnAwake = false;//playonawke is set to false
            soundsarray[i].source.clip = soundsarray[i].clip;
            soundsarray[i].source.volume = soundsarray[i].volume;
            soundsarray[i].source.pitch = soundsarray[i].pitch;
            soundsarray[i].source.loop = soundsarray[i].loop;

        }


    }



    public void pauseall()
    {
        for (int i = 0; i < soundsarray.Length; i++)
        {
            soundsarray[i].source.Pause();
        }
    }

   


    public void unpauseall()
    {
        for (int i = 0; i < soundsarray.Length; i++)
        {
            soundsarray[i].source.UnPause();
        }
    }
    public AudioSource findsound(string inputname)
    {

        AudioSource rsource=null;

        int i = 0;

        for (i = 0; i < soundsarray.Length; i++)
        {

            if (soundsarray[i].namee.ToLower() == inputname.ToLower())
            {
                rsource = soundsarray[i].source;
                return rsource;
            }
             
        }

        if (i == soundsarray.Length)
        {
            Debug.LogWarning(inputname + ": sound with this namee was not found");
        }

        return rsource;
    }


    public void play(string inputname)// if the sound is already played than  does not play it.
    {
        Debug.Log("audioManger got " + inputname);


        if (findsound(inputname) != null)
        {
            if (!findsound(inputname).isPlaying)
            {
                findsound(inputname).Play();
            }

        }
        
    }
   public void playtime(string inputname,float inputtime)// play the sound after inputtime
    {
        if (findsound(inputname) != null)
        {
            if (!findsound(inputname).isPlaying)
            {
                findsound(inputname).PlayDelayed(inputtime);
            }

        }

    }




    public void alwaysplay(string inputname)// if the sound is already played than replay it.
    {
        Debug.Log("audioManger got " + inputname);

        if (findsound(inputname) != null)
        {
         
            findsound(inputname).Play();
        }
          
    }
 
  

    public void stop(string inputname)//stop the sound
    {
        if (findsound(inputname) != null)
        {
            findsound(inputname).Stop();
        }
      
    }

    public void stopAll()
    {
        for (int i = 0; i < soundsarray.Length; i++)
        {
            soundsarray[i].source.Stop();
        }
    }
    public void unpause(string inputname)//stop the sound
    {
        if (findsound(inputname) != null)
        {
            findsound(inputname).UnPause();
        }

    }


}
