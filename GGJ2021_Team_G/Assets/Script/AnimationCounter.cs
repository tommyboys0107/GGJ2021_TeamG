using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCounter : MonoBehaviour
{
    public BossUnit boss;

    public void Counter()
    {
        if (boss != null)
        {
            //boss.AnimationPlayCount();
            boss.PauseFrame();
        }
    }
}
