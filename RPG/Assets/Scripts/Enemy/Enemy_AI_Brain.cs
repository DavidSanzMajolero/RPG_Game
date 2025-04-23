using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Brain : MonoBehaviour
{
    private EnemyReferences enemyReferences;
    private StateMachine stateMachine;

    private void Start()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        stateMachine = new StateMachine();

        //ESTADOS
        CoverArea coverArea = FindObjectOfType<CoverArea>();
        var runToCover = new EnemyState_RunToCover(enemyReferences, coverArea);
        var delayAfterRun = new EnemyState_Delay(2f);
        var cover = new EnemyState_Cover(enemyReferences);

        //TRANSICIONES
        At(runToCover,delayAfterRun, () => runToCover.HasArrivedAtDestination());
        At(delayAfterRun, cover, () => delayAfterRun.IsDone());

        stateMachine.SetState(runToCover);

        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
    }

    private void Update()
    {
        stateMachine.Tick();
    }


    private void OnDrawGizmos()
    {
        if (stateMachine != null)
        {
            //Gizmos.color = stateMachine.GetGizmoColor();
            Gizmos.DrawSphere(transform.position + Vector3.up * 3, 0.4f);
        }
    }

}
