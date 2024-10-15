using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsLessonParticleDeathExplosion : MonoBehaviour
{
    //The particle event that will be spawned when the explosion function is called
    public ParticleSystem explosionParticle;

    /// <summary>
    /// Spawns the particle system at the location of the object that was killed
    /// </summary>
    /// <param name="atObject">The object that exploded</param>
    private void Explode(GameObject atObject)
    {
        Instantiate(explosionParticle, atObject.transform.position, atObject.transform.rotation);
    }

    /// <summary>
    /// On enable, subscribe Explode to OnTimmyKilled
    /// </summary>
    private void OnEnable()
    {
        EventsLessonScript.OnTimmyKilled += Explode;
    }

    /// <summary>
    /// On disable, unsubscribe Explode to OnTimmyKilled to prevent issues
    /// </summary>
    private void OnDisable()
    {
        EventsLessonScript.OnTimmyKilled -= Explode;
    }
}
