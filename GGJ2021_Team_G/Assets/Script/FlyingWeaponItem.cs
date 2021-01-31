using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyingWeaponItem : ItemCollideHandler
{
    public float flyingTime = 0;
    protected override void DoTouch(Collider collision)
    {
        if (gameObject.activeSelf == false)
        {
            return;
        }

        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            GameObject flying = Instantiate(this.gameObject);
            Destroy(flying.GetComponent<FlyingWeaponItem>());
            BossUnit bu = boss.GetComponent<BossUnit>();
            bu.TurnBossVisible();

            flying.transform.localPosition = Player.Instance.transform.localPosition;
            print(flying.transform.localPosition);
            print(bu.weekPos);
            flying.transform.DOMove(bu.weekPos, flyingTime).OnComplete(() => {
                flying.gameObject.SetActive(false);
                //ready to play result animation
                GameManager.GameEnd();
            });
        }
        this.gameObject.SetActive(false);
    }
}
