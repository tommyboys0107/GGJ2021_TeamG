using UniRx;
using System;
using UnityEngine;

public static class GameManager 
{

    //�{�b���A
    //���ܶ���

    static IDisposable dead;
    //���`����
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
