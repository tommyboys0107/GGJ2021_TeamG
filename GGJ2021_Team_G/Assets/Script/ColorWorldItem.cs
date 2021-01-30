using UnityEngine;

public class ColorWorldItem : ItemCollideHandler
{
    void Awake()
    {
        switchGrayScale = GameObject.Find("Volume").GetComponent<SwitchGrayScale>();       
    }

    private SwitchGrayScale switchGrayScale;
    protected override void DoTouch(Collider collision)
    {
        switchGrayScale.SetGrayScale(false);
    }
}
