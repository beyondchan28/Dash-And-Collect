using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;


public class Enemy : MonoBehaviour
{
    // public EnemyStatus enemyStatus;
    public enum STATE
    {
        MOVE, STOP, PATROL
    }
    public STATE currentState = STATE.MOVE;
    public float minimumStopDistance = 1f;
    public float moveSpeed = 1f;
    public float stopTime = 2f;
    public int patrolAmount = 3;
    public int patrolCount = 0;

    public Transform playerTransform;
    private float stopCount = 0f;
    private Vector3 patrolA;
    private Vector3 patrolB;
    private Vector3 target;
    private float distance;

    void Start()
    {
        patrolA = new Vector3(
                Random.Range(-8f, 8f),
                Random.Range(-4f, 4f),
                0f
            );
        patrolB = patrolA - new Vector3(3f, 3f, 0f);
        transform.position = patrolA;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        target = playerTransform.position;
    }

    void Update()
    {
        ProcessState();
        if (currentState != STATE.STOP)
        {
            distance = Vector3.Distance(transform.position, target);
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }
    }

    // when player hit enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Player player = collision.gameObject.GetComponent<Player>();
            player.healthComponent.Hurt();
            if (currentState != STATE.STOP)
            {
                ChangeState(STATE.STOP);
            }
        }
    }

    void ChangeState(STATE es)
    {
        currentState = es;
        switch (es)
        {
            case STATE.MOVE:
                target = playerTransform.position;
                break;
            case STATE.STOP:
                stopCount = 0;
                break;
            case STATE.PATROL:
                patrolCount = 0;
                target = patrolA;
                break;
        }
    }

    void ProcessState()
    {
        if (currentState == STATE.STOP)
        {
            stopCount += Time.deltaTime;
            if (stopCount >= stopTime)
            {

                ChangeState(STATE.PATROL);
            }
        }
        else if (currentState == STATE.MOVE)
        {
            target = playerTransform.position;
        }

        if (distance <= minimumStopDistance)
        {
            if (currentState == STATE.PATROL)
            {
                if (target == patrolB)
                {
                    target = patrolA;
                    patrolCount += 1;
                    if (patrolCount == patrolAmount)
                    {
                        ChangeState(STATE.MOVE);
                    }
                }
                else
                {
                    target = patrolB;
                }
            }
        }
    }
}
