using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSFX : MonoBehaviour
{
    public string audioName;
    public void StickSound()
    {
        AudioManager.Instance.PlaySFX(audioName);
    }
}
