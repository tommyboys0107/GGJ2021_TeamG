using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VisibleBossItem : ItemCollideHandler
{
    protected override void DoTouch(Collider collision)
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            boss.GetComponent<BossUnit>().TurnBossVisible();
        }
        this.gameObject.SetActive(false);
        GameManager.Stage_MoveForward(new ToKillBoss_Stage());

        Light light = GameObject.Find("DirectionalLight").GetComponent<Light>();
        light.DOIntensity(1.0f, 2.0f);

    }
}
