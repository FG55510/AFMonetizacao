using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineManager : MonoBehaviour
{
    public List<SlotMachine> slotMachines;
    public List<Prize> prizes;

    private void Awake()
    {
        foreach (var item in slotMachines)
        {
            item.ConfigUI(prizes);
        }
    }

    [ContextMenu("Start")]
    public void StartTurning()
    {
        StartCoroutine(StartTurningCoroutine());
    }

    [ContextMenu("Stop")]
    public void StopTurning()
    {
        StartCoroutine (StopTurningCoroutine());
    }

    public IEnumerator StartTurningCoroutine()
    {
        foreach (var item in slotMachines)
        {
            item.StartSpin();
            yield return new WaitForSeconds(Random.Range(1,4));
        }
    }

    public IEnumerator StopTurningCoroutine()
    {
        foreach (var item in slotMachines)
        {
            item.isStopping = true;
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(CheckResult());
    }

    public IEnumerator CheckResult()
    {
        bool stilTurning = true;
        while (stilTurning)
        {
            bool result = true;
            foreach (var item in slotMachines)
            {
                if (!item.endedTurning)
                {
                    result = false;
                    break;
                }
            }

            if (result)
            {
                stilTurning = false;
            }

            yield return null;
        }

        int resultID = slotMachines[0].prizeID;
        foreach (var item in slotMachines)
        {
            if (item.prizeID != resultID)
            {
                Debug.Log("NÂO ACERTOU");
                yield break;
            }
        }
        Debug.Log("ACERTOU");
    }
}
