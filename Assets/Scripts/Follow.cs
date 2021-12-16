using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent Enemy;
    public Transform Player;
    public float TriggerDistance;
    public float hittingdistance;
    public float walkanimstartspeed;
    public Animator anim;
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < TriggerDistance)
        {
            Enemy.SetDestination(Player.position);
            anim.SetBool("walk", true);
        }

        if(Vector3.Distance(transform.position, Player.transform.position) < hittingdistance)
        {
            anim.SetBool("swing", true);
        }
        else
        {
            anim.SetBool("swing", false);
        }
    }

}
