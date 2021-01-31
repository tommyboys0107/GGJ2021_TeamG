using UnityEngine;
using DG.Tweening;

public class NotImportItem : ItemCollideHandler
{
    public GameObject GO;
    public GameObject Image;
    protected override void DoTouch(Collider collision)
    {
        GO.transform.DOMoveY(0,2f);
        Image.SetActive(true);
        gameObject.SetActive(false);
    }
}

