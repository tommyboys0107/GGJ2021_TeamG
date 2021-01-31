using UnityEngine;
using UnityEngine.Playables;

public class Glasses : ItemCollideHandler
{
    [SerializeField]
    PlayableDirector playableDirector = null;

    protected override void DoTouch(Collider collision)
    {
        Player player= collision.gameObject.GetComponent<Player>();
        player.changeMove();
        playableDirector.Play();
        GameManager.Stage_MoveForward(new _3DStage());
        gameObject.SetActive(false);
    }
}
