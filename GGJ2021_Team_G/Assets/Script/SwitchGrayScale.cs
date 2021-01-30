using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering;

public class SwitchGrayScale : MonoBehaviour
{
    public bool defaultGray = true;
    // Start is called before the first frame update
    void Start()
    {
        SetGrayScale(defaultGray);
    }

    public void SetGrayScale(bool gray)
    {
        Volume volume = GetComponent<Volume>();
        var profile = volume.profile;
        var list = profile.components;
        IReadOnlyCollection<VolumeParameter> collection = null;
        for (int i = 0; i < list.Count; i++)
        {
            collection = list[i].parameters;
        }

        var e = collection.GetEnumerator();

        VolumeParameter vp = gray ? new FloatParameter(-100) : new FloatParameter(0);

        while (e.MoveNext())
        {
            if (e.Current.overrideState)
            {
                e.Current.SetValue(vp);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
