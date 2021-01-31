using UnityEngine;
using UnityEngine.Playables;

public class Glasses : ItemCollideHandler
{

    protected override void DoTouch(Collider collision)
    {
        Player player= collision.gameObject.GetComponent<Player>();
        player.changeMove();
        TimelinePlayer.PlayDimension();
        GameManager.Stage_MoveForward(new VisableBosStage());
        gameObject.SetActive(false);
    }
}
