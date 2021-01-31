using UnityEngine;

public class ColorWorldItem : ItemCollideHandler
{
   protected override void DoTouch(Collider collision)
    {
        PostProcessingManager.instance.TweenGrayEffect(false);
        gameObject.SetActive(false);
    }
}

