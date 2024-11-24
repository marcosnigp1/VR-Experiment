//Done with help of the following guide: https://discussions.unity.com/t/play-sound-at-certain-time/562789/6

using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour
{
    private bool audio_control = false;
    public AudioSource startinstructions;
    public AudioSource y_button;
    public AudioSource instructions;
    public AudioSource end;

    void Update()
    {
        //Play initial audio.
        if (audio_control == false)
        {
            audio_control = true;
            startinstructions.PlayDelayed(5); 
        }
    }

    public void StopInitialAudio()
    {
    audio_control = true;
    startinstructions.Stop();
    }


    //These can be useful later in the future...
    public void playYButtonInstruction(){
        y_button.Stop();
        y_button.Play();
    }

    public void playInstructions(){
        y_button.Stop(); // Just in case.
        instructions.Stop();
        instructions.Play();
    }

    public void playFinalInstructions(){
        instructions.Stop(); // Just in case.
        end.Play();
    }
}
