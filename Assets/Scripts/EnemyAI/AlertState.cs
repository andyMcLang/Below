using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : IEnemyState
{
    private StatePatternEnemy enemy;
    float searchTimer;

    public AlertState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Search();
        Look();
    }
    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToAlertState()
    {
        // Tätä ei voida käyttää
    }

    public void ToChaseState()
    {
        searchTimer = 0;
        enemy.currentState = enemy.chaseState;
    }

    
    public void ToPatrolState()
    {
        searchTimer = 0;
        enemy.currentState = enemy.patrolState;
    }

    public void ToTrackingState()
    {


    }

    void Search()
    {
        enemy.indicator.material.color = Color.yellow;
        enemy.navMeshAgent.isStopped = true;
        enemy.transform.Rotate(0, enemy.searchTurnSpeed * Time.deltaTime, 0);
        searchTimer += Time.deltaTime;

        if(searchTimer >= enemy.searchingDuration)
        {
            ToPatrolState();

        }
    }

    void Look()
    {

        Debug.DrawRay(enemy.eyes.position, enemy.eyes.forward * enemy.sightRange, Color.yellow, 1f);
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.position, enemy.eyes.forward,
            out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }
    }

}
