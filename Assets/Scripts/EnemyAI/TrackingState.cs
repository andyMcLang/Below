using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingState : IEnemyState
{
    private StatePatternEnemy enemy;

    public TrackingState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Hunt();
        Look();
    }
    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToAlertState()
    {
        enemy.currentState = enemy.alertState;
    }

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }

    public void ToPatrolState()
    {
        // Tuskin mennään patrolliin
    }

    public void ToTrackingState()
    {
        // Tätä ei voida käyttää. Ollan jo tracking tilassa
    }


    void Hunt()
    {
        enemy.indicator.material.color = Color.blue;
        enemy.navMeshAgent.destination = enemy.trackingTarget;
        //Debug.Log(enemy.trackingTarget);
        enemy.navMeshAgent.isStopped = false;

        // Jos vihollinen on tracking positiossa, menee se AlertStateen
        if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance &&
            !enemy.navMeshAgent.pathPending)
        {
            ToAlertState();
        }

    }

    void Look()
    {

        Debug.DrawRay(enemy.eyes.position, enemy.eyes.forward * enemy.sightRange, Color.blue, 1f);
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.position, enemy.eyes.forward,
            out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }
    }
}
