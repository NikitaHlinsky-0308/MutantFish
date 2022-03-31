using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class WormEnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public enum AIState
    {
        isIdle, isChasing, isAttacking
    };
    public AIState currentState;

    public float chaseRange;

    public float attackRange = 1f;
    public float timeBetweenAttacks = 2f;
    private float attackCounter;
    private float defaultSpeed;

    [SerializeField] private int health;
    [SerializeField] private int buffChance;

    private void Start()
    {
        defaultSpeed = agent.speed;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerMovement.instance.transform.position);


        //  AboveGround   bool
        //  UnderGround   bool
        //  Die                  trigger
        //  Attack              trigger


        switch (currentState)
        {
            case AIState.isIdle:
                //anim.SetBool("AboveGround", true);
                agent.speed = 0;

                if (distanceToPlayer <= chaseRange)
                {
                    // somwhere here can be delay

                    currentState = AIState.isChasing;
                    anim.SetBool("UnderGround", true);
                    agent.speed = defaultSpeed;
                }

                break;

            case AIState.isChasing:

                agent.SetDestination(PlayerMovement.instance.transform.position);

                if (distanceToPlayer <= attackRange)
                {
                    currentState = AIState.isAttacking;
                    anim.SetTrigger("Attack");
                    //anim.SetBool("Moving", false);

                    agent.velocity = Vector3.zero;
                    agent.isStopped = true;
                }
                if (distanceToPlayer > chaseRange)
                {
                    currentState = AIState.isChasing;

                    agent.velocity = Vector3.zero;
                    agent.SetDestination(transform.position);
                }

                break;

            case AIState.isAttacking:

                transform.LookAt(PlayerMovement.instance.transform.position, Vector3.up);
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    if (distanceToPlayer < attackRange)
                    {
                        anim.SetTrigger("Attack");
                        attackCounter = timeBetweenAttacks;
                    }
                    else
                    {
                        currentState = AIState.isIdle;


                        agent.isStopped = false;
                    }
                }

                break;
        }
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            //EnemyManager.instance.EnemyCount--;
            EnemyManager.instance.EnemyCount += 1;
            Invoke(nameof(DestroyEnemy), 0.1f);
        }
    }
    private void DestroyEnemy()
    {


        if (EnemyManager.instance != null)
        {
            EnemyManager.instance.AddScore(100);
            EnemyManager.instance.UpdateUI();
        }

        if (Random.Range(1, 101) <= buffChance && SpawnCollectables.instance != null)
        {

            SpawnCollectables.instance.SpawnItem(Random.Range(0, 3), transform.position);
        }


        StartCoroutine(DelayBeforeDie(0.75f));

    }

    private IEnumerator DelayBeforeDie(float delay)
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
