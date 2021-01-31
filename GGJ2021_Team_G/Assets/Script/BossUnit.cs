using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����µ۪��a�ݡA��Ǧ�m���]���C
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
    private int step = 0;
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

    public void PlayBossAttack(bool state)
    {
        animator.SetBool("attack", state);
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

    public void AnimationPlayCount()
    {
        if (step + 1 < 5)
        {
            step++;
        }
        else
        {
            step = 0;
        }

        animator.SetInteger("step", step);
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
