using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemCollideHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player")
        {
            DoTouch(other);
        }
    }
    protected abstract void DoTouch(Collider collision);
}
