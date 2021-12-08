using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent Enemy;
    public Transform Player;

    private void Update()
    {
        Enemy.SetDestination(Player.position);
    }

}
