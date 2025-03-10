using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : ScriptedMovement 
{


    private void Start()
    {
        var scriptActions = new List<ScriptAction>
        {
            new(){ ActionType = ActionType.MoveLeft },
            new(){ ActionType = ActionType.Wait, WaitTime = 1.5f },
            new(){ ActionType = ActionType.StopMoveLeft},
            new(){ ActionType = ActionType.Wait, WaitTime = 0.5f },
            new(){ ActionType = ActionType.MoveRight },
            new(){ ActionType = ActionType.Wait, WaitTime = 1.5f },
            new(){ ActionType = ActionType.StopMoveRight},
            new(){ ActionType = ActionType.Wait, WaitTime = 0.5f },
        };
        this.RepeatForever = true;
        this.SpeedXBoost = 0.5f;
        this.Initialize(scriptActions);
    }

}