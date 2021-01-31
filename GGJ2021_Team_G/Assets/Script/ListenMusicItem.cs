using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenMusicItem : ItemCollideHandler
{
    protected override void DoTouch(Collider collision)
    {
        MusicManager.instance.UnlockFunction();
        GameManager.Stage_MoveForward(new _3ddStage());
        this.gameObject.SetActive(false);
    }
}
