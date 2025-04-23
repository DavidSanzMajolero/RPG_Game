using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyState_Cover : IState
{
    private EnemyReferences enemyReferences;    
    private StateMachine stateMachine;

    public EnemyState_Cover(EnemyReferences enemyReferences)
    {
        this.enemyReferences = enemyReferences;

        stateMachine = new StateMachine();

        //ESTADOS
        var enemyShoot = new EnemyState_Shoot(enemyReferences);
        var enemyDelay = new EnemyState_Delay(1f);
        var enemyReload = new EnemyState_Reload(enemyReferences);

        //trasitions
        At(enemyShoot, enemyReload, () => enemyReferences.shooter.ShouldReload());
        At(enemyReload, enemyDelay, () => !enemyReferences.shooter.ShouldReload());
        At(enemyDelay, enemyShoot, () => enemyDelay.IsDone());

        stateMachine.SetState(enemyShoot);

        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
    }

    public void OnEnter()
    {
        enemyReferences.animator.SetBool("combat", true);
    }
    public void OnExit()
    {
        enemyReferences.animator.SetBool("combat", false);
    }
    public void Tick()
    {
        stateMachine.Tick();
    }
    public Color GizmoColor()
    {
        return Color.gray;
    }
}
