using UnityEngine;

public class ChangeHumanItem : ItemCollideHandler
{
    protected override void DoTouch(Collider collision)
    {
        Player.Instance.ChangeToHuman();
    }
}
