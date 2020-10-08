using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private StatePatternEnemy enemy;
    private int nextWayPoint;

    public PatrolState(StatePatternEnemy statePatternEnemy)
    {
        this.enemy = statePatternEnemy;

    }
    
    public void UpdateState()
    {
        Patrol();
        Look();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ToAlertState();
        }
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
        // Ei voida käyttää
    }

    public void ToTrackingState()
    {

    }

    void Look()
    {

        Debug.DrawRay(enemy.eyes.position, enemy.eyes.forward * enemy.sightRange, Color.green, 1f);
        RaycastHit hit;
        if(Physics.Raycast(enemy.eyes.position, enemy.eyes.forward, 
            out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }
    }


    void Patrol()
    {
        enemy.indicator.material.color = Color.green;
        enemy.navMeshAgent.destination = enemy.wayPoints[nextWayPoint].position;
        enemy.navMeshAgent.isStopped = false;

        // Vaihdetaan waypointtia kun päästään nykyiseen waypointiin
        if(enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && 
            !enemy.navMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
        }

    }

 
}
