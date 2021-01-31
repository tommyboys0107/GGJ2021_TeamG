using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemCollideHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player")
        {
            ParticleSystemPlay();
            DoTouch(other);
        }
    }
    protected abstract void DoTouch(Collider collision);
    protected void ParticleSystemPlay()
    {
        GameManager.source.Particle.transform.position = this.transform.position;
        GameManager.source.Particle.Play();
    }
}
