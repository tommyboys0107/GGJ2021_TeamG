using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameManager.Stage_MoveForward(new Stage4());
    }
}
