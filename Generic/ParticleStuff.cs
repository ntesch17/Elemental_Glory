using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStuff : MonoBehaviour
{
    ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;

    // Start is called before the first frame update
    void Awake()
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.main.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
    }

    // Update is called once per frame
    /*
    void Update()
    {
        int numParticlesAlive = m_System.GetParticles(m_Particles);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            m_Particles[i].velocity += Vector3.up * m_Drift;
            Vector3 theScale = m_Particles[i].;
            theScale.x = xScale;
            transform.localScale = theScale;
        }
    }void LateUpdate()
    {
        int numParticlesAlive = m_System.GetParticles(m_Particles);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            m_Particles[i].velocity += Vector3.up * m_Drift;
        }
    }*/
}
