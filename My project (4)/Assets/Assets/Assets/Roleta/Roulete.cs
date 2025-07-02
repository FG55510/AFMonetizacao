using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulete : MonoBehaviour
{
    public Rigidbody body;
    public Vector3 torque;
    public RectTransform spinRect;

    public Action<float> OnStopTurnig;

    void Start()
    {
        StartSpin();
    }

    [ContextMenu("start")]
    public void StartSpin()
    {
        float torqueZ = UnityEngine.Random.Range(200, 500);
        torque = new Vector3(0, 0, torqueZ);

        body.AddTorque(torque, ForceMode.Acceleration);

        StartCoroutine(WaitingStop());
    }

    public IEnumerator WaitingStop()
    {
        yield return new WaitForSeconds(1);

        while (body.angularVelocity.magnitude >0.1f)
        {

            yield return null;
        }

        Debug.Log("ACABOU COM O ANGULO DE " + spinRect.localEulerAngles.z);

        OnStopTurnig.Invoke(spinRect.localEulerAngles.z);
    }
}
