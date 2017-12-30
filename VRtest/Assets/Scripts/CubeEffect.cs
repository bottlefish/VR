﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeEffect : MonoBehaviour {

    public ParticleSystem lowestParticle;
    public List<ParticleSystem> normalShakeParticle = new List<ParticleSystem>();
    public List<ParticleSystem> highestShakeParticle = new List<ParticleSystem>();

    private float m_timer = 0; //震动效果用

    void Update() {
        TimerForEffect();
    }

    public void ShakeOnce() {
        this.transform.DOShakePosition(0.1f, new Vector3(0.02f, 0f, 0.02f), 100, 100);
        foreach (ParticleSystem p in normalShakeParticle) {
            p.Play();
        }
    }

   

    public void LowestShaking() {
        if (m_timer == 0) {
            this.transform.DOShakePosition(0.1f, new Vector3(0.01f, 0f, 0.01f), 100, 100);
            lowestParticle.Play();
        }
    }

    public void HighestShaking() {
        if (m_timer == 0) {
            this.transform.DOShakePosition(0.1f, new Vector3(0.01f, 0f, 0.01f), 100, 100);
            foreach (ParticleSystem p in highestShakeParticle) {
                p.Play();
            }
        }
    }

    void TimerForEffect() {
        m_timer += Time.deltaTime;
        if (m_timer >= 0.1) {
            m_timer = 0;
        }
    }
}
