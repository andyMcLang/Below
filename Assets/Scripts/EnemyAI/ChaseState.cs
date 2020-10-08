using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    private StatePatternEnemy enemy;

    public ChaseState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Chase();
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
        // Ei voida käyttää, koska ollaan jo ChaseStatessa
    }

    public void ToPatrolState()
    {
        // Ei nyt käytössä. Mutta voidaan käyttää, jos tulee tarve.
        enemy.currentState = enemy.patrolState;
    }

    public void ToTrackingState()
    {
        enemy.trackingTarget = enemy.chaseTarget.position;
        enemy.currentState = enemy.trackingState;

    }

    void Chase()
    {
        enemy.indicator.material.color = Color.red;
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
        enemy.navMeshAgent.isStopped = false;

    }

    void Look()
    {

        Debug.DrawRay(enemy.eyes.position, enemy.eyes.forward * enemy.sightRange, Color.red, 1f);
        RaycastHit hit;
        Vector3 enemyToTarget = enemy.chaseTarget.position - enemy.eyes.position;
        if (Physics.Raycast(enemy.eyes.position, enemyToTarget,
            out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            // Vihollinen on kohdistanu katseensa pelaajaan
            enemy.chaseTarget = hit.transform;
        }
        else
        {
            // Kohda on hävinnyt näkösäteen edestä.
            ToTrackingState();
        }
    }
}
