using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 不停朝著玩家看，對準位置的魔王。
/// </summary>
public class BossUnit : MonoBehaviour
{
    public GameObject body;
    public GameObject fogEffect;
    public GameObject weekPoint;
    public Animator animator;

    public Vector3 weekPos
    {
        get
        {
            if (weekPoint != null)
            {
                return weekPoint.transform.position;
            }
            return Vector3.zero;
        }
    }

    public float rpc = 1080f;
    private float lerpSpeed = 0f;
    private float lerpTimer = 0;
    private bool startLerpRotate = false;
    private Quaternion originalRotation;
    private Quaternion lookAtRotation;
    private int playCounter = 0;
    private int step = 0;

    const float offset_time = 0f;
    const float anim1_time = 2f;
    const float anim2_time = 2.567f;
    const float anim3_time = 3.1f;
    // Start is called before the first frame update
    void Start()
    {
        if (body != null)
        {
            body.SetActive(false);
        }

        if (fogEffect != null)
        {
            fogEffect.SetActive(false);
        }
    }

    public void PlayBossAttack()
    {
        switch (step)
        {
            case 0:
                step = 1;
                break;
            case 1:
                step = 2;
                break;
            case 2:
                step = 3;
                break;
            case 3:
                step = 1;
                break;
        }
        animator.SetInteger("attack", step);
        animator.speed = 1;
    }

    public float BossAttackAnimationTime()
    {
        float animator_time = 0;
        switch (step)
        {
            case 1:
                animator_time = anim1_time;
                break;
            case 2:
                animator_time = offset_time + anim1_time + anim2_time;
                break;
            case 3:
                animator_time = offset_time + anim1_time + anim2_time + anim3_time;
                break;
            default:
                animator_time = anim1_time;
                break;
        }

        return animator_time;
    }

    public void TurnBossVisible()
    {
        if (body != null)
        {
            body.SetActive(true);
        }
        if (fogEffect != null)
        {
            fogEffect.SetActive(true);
        }
    }

    public void PauseFrame()
    {
        playCounter++;
        if (playCounter == step)
        {
            playCounter = 0;
            animator.speed = 0;
            animator.SetInteger("attack", 0);
            Invoke("ResetToIdle", 0.75f);
        }
    }

    public void ResetToIdle()
    {
        animator.speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance == null)
        {
            return;
        }

        if (startLerpRotate == false)
        {
            originalRotation = transform.rotation;
            Transform target = Player.Instance.transform;
            transform.LookAt(target);
            lookAtRotation = transform.rotation;
            transform.rotation = originalRotation;
            float rotate_angle = Quaternion.Angle(originalRotation, lookAtRotation);
            lerpSpeed = rpc / rotate_angle;
            lerpTimer = 0.0f;
            startLerpRotate = true;
        }
        else
        {
            lerpTimer += Time.deltaTime * lerpSpeed;
            transform.rotation = Quaternion.Lerp(originalRotation, lookAtRotation, lerpTimer);
            if (lerpTimer >= 1)
            {
                transform.rotation = lookAtRotation;
                startLerpRotate = false;
            }
        }
    }
}
