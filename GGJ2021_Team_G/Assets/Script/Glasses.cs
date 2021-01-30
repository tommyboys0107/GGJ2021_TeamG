using UnityEngine;

public class Glasses : ItemCollideHandler
{
    protected override void DoTouch(Collider collision)
    {
        Player player= collision.gameObject.GetComponent<Player>();
        player.changeMove();
    }
}
