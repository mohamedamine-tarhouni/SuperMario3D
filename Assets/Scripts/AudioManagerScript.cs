using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private AudioSource _audioSource_coin;    
    [SerializeField]
    private AudioSource _audioSource_bump;    
    [SerializeField]
    private AudioSource _audioSource_getPowerUp;    
    [SerializeField]
    private AudioSource _audioSource_PowerUpOut;    
    [SerializeField]
    private AudioSource _audioSource_Pause;    
    [SerializeField]
    private AudioSource[] _audioSource_MarioJump;    
    [SerializeField]
    private AudioSource[] _audioSource_MarioHighJump;
    private int _jumps=0;
    private int _highJumps=0;
    public void playCoinSound()
    {
        _audioSource_coin.Play();
    }    
    public void playBumpSound()
    {
        _audioSource_bump.Play();
    }    
    public void playgetPowerUp()
    {
        _audioSource_getPowerUp.Play();
    }    
    public void playPowerUpOut()
    {
        _audioSource_PowerUpOut.Play();
    }    
    public void playPause()
    {
        _audioSource_Pause.Play();
    }    
    public void playMarioJump()
    {
        
        _audioSource_MarioJump[_jumps].Play();
        _jumps++;
        if (_jumps >= _audioSource_MarioJump.Length)
        {
            _jumps = 0;
        }
    }    
    public void playMarioHighJump()
    {

        _audioSource_MarioHighJump[_highJumps].Play();
        _highJumps++;
        if (_highJumps >= _audioSource_MarioHighJump.Length)
        {
            _highJumps = 0;
        }
    }
}
