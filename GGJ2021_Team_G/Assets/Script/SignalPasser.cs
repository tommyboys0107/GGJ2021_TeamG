using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalPasser : MonoBehaviour
{
    public void CallStartGame()
    {
        GameManager.Start();
    }
}
