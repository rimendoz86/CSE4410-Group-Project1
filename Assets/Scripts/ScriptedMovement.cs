using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum ActionType {
    MoveRight,
    MoveLeft,
    MoveUp,
    MoveDown,
    StopMoveRight,
    StopMoveLeft,
    StopMoveUp,
    StopMoveDown,
    Jump,
    Wait,
    EndScript,
    DestroyGameObject
}

public class ScriptAction {
    public ActionType ActionType;
    public float WaitTime;
}
public class ScriptedMovement :  Movement
{
    List<ScriptAction> ScriptActions;
    public bool RepeatForever;
    [SerializeField]
    public float DelayStart = 0f;
    public void Initialize(List<ScriptAction> scriptActions, float gravity = 3f)
    {
        gameLogic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
        this.ScriptActions = scriptActions;
        this.RigidBody = GetComponent<Rigidbody2D>();
        this.RigidBody.gravityScale = gravity;
        this.SetControllerType(ControllerType.Scripted);
        this.IsInitialized = true;
        StartCoroutine(this.BeginScript());

    }

    IEnumerator BeginScript()
    {
        if(DelayStart != 0f) 
            yield return new WaitForSeconds(DelayStart);

        do
        {
            for (int i = 0; i < ScriptActions.Count; i++)
            {
                if (!gameLogic.GameIsActive) {
                    i--;
                    yield return new WaitForSeconds(1f);
                    continue;
                }
                ScriptAction action = this.ScriptActions[i];
                switch (action.ActionType)
                {
                    case ActionType.MoveRight:
                        this.MoveRight(true);
                        break;
                    case ActionType.MoveLeft:
                        this.MoveLeft(true);
                        break;
                    case ActionType.MoveUp:
                        this.MoveUp(true);
                        break;
                    case ActionType.MoveDown:
                        this.MoveDown(true);
                        break;
                    case ActionType.StopMoveRight:
                        this.MoveRight(false);
                        break;
                    case ActionType.StopMoveLeft:
                        this.MoveLeft(false);
                        break;
                    case ActionType.StopMoveUp:
                        this.MoveUp(false);
                        break;
                    case ActionType.StopMoveDown:
                        this.MoveDown(false);
                        break;
                    case ActionType.Jump:
                        this.Jump();
                        break;
                    case ActionType.Wait:
                        yield return new WaitForSeconds(action.WaitTime);
                        break;
                }

            }
        } while (this.RepeatForever);


    }

}
