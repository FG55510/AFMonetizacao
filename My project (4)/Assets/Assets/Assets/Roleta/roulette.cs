using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roulette : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 torque;

    public Action OnEndTurning;

    private void Awake()
    {
        OnEndTurning += TurningEnded;
    }

    private void OnDestroy()
    {
        OnEndTurning -= TurningEnded;
    }

    [ContextMenu("turn")]
    public void Turn()
    {
        rb.AddTorque(torque,ForceMode.Force);

        StartCoroutine(CallOnEndTurning());
    }

    public IEnumerator CallOnEndTurning()
    {
        yield return new WaitForSeconds(1);


        while (rb.angularVelocity.magnitude > 0.02f)
        {
            Debug.Log(rb.angularVelocity.magnitude);
            yield return null;
        }
        Debug.Log(rb.angularVelocity);
        OnEndTurning?.Invoke();
    }

    public void TurningEnded()
    {
        Debug.Log($"ANGULO FINAL {rb.transform.localEulerAngles}");
    }
}
