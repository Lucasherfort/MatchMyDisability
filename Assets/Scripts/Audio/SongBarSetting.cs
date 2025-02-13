﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongBarSetting : MonoBehaviour
{

    [SerializeField] private int m_songScale = 10;
    [SerializeField] private Slider m_songSlider;
    private float m_deltat;
    private float m_volume;
    private bool m_isMute;



    private void Start()
    {
        m_isMute = false;
        m_deltat = 100.0f / (float)m_songScale;
        m_volume = (float)m_songScale / 2.0f * m_deltat;
        m_songSlider.value = m_volume / 100f;
        //Debug.Log("m_deltat = " + m_deltat);
    }


    public void DecreaseVolume()
    {
        if (m_isMute)
        {
            Debug.Log("Volume is muted");
            return;
        }
        if (m_volume > 0)
        {
            m_volume -= m_deltat;
            m_songSlider.value = m_volume / 100f;
            Debug.Log("Song decreases: " + m_volume);
        }
        else
        {
            m_volume = 0f;
            Debug.Log("Song can't be decreased");
        }

        AudioListener.volume = GetVolume();
    }

    public void IncreaseVolume()
    {
        if (m_isMute)
        {
            m_isMute = false;
            m_volume = m_deltat;
            m_songSlider.value = m_volume / 100f;
            return;
        }
        if (m_volume < 100)
        {
            m_volume += m_deltat;
            m_songSlider.value = m_volume / 100f;
            Debug.Log("Song increases: " + m_volume);
        }
        else
        {
            m_volume = 100f;
            Debug.Log("Song can't be increased");
        }

        AudioListener.volume = GetVolume();
    }

    public void MuteVolume()
    {
        if (m_isMute)
        {
            m_isMute = false;
            m_songSlider.value = m_volume / 100f;
        }
        else
        {
            m_isMute = true;
            m_songSlider.value = 0f;
        }

        AudioListener.volume = GetVolume();
    }

    public float GetVolume()
    {
        if (m_isMute)
        {
            return 0f;
        }
        return m_volume / 100f;
    }


    
    // Update is called once per frame
    void Update()
    {
        //transform.localScale
        if (Input.GetKeyDown(KeyCode.A))
        {
            IncreaseVolume();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            DecreaseVolume();
        }
    }
}
