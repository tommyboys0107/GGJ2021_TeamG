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
        GameManager.source.ItemColorWorld.SetActive(true);
        gameObject.SetActive(false);
    }
}
