using UnityEngine;
using System.Collections;

public class GameTarget : Destructable {

    public GameManager GameManager;

    public override void OnDeath()
    {
        if(!Destroyed)
        {
            GameManager.TargetDestroyed();
        }
        base.OnDeath();
    }

}
