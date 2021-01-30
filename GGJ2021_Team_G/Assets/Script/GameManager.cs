using UniRx;
using System;
using UnityEngine;

public static class GameManager 
{

    //現在狀態
    //提示項目

    static IDisposable dead;
    //死亡控制
    public static void Dead60Sec(Player player)
    {
        dead = Observable.Timer(TimeSpan.FromSeconds(60))
            .Subscribe(_=> ReSet())
            .AddTo(player);
    }
    private static void ReSet()
    {

    }
}
