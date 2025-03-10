using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : ScriptedMovement
{

    private void Start()
    {
        var scriptActions = new List<ScriptAction>
        {
            new(){ ActionType = ActionType.MoveUp },
            new(){ ActionType = ActionType.Wait, WaitTime = 1.5f },
            new(){ ActionType = ActionType.StopMoveUp},
            new(){ ActionType = ActionType.Wait, WaitTime = 0.5f },
            new(){ ActionType = ActionType.MoveDown },
            new(){ ActionType = ActionType.Wait, WaitTime = 1.5f },
            new(){ ActionType = ActionType.StopMoveDown},
            new(){ ActionType = ActionType.Wait, WaitTime = 0.5f },
        };
        this.RepeatForever = true;
        this.SpeedYBoost = 0.5f;
        
        this.Initialize(scriptActions, 0f);
    }


}
