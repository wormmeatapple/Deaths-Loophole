using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodLoss : MonoBehaviour
{
    public float bloodLossInterval = 3;
    public float amountOfBlood = 4;
    public healthBarFill health;

    private Coroutine repeatCoroutine;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<healthBarFill>();
        startBloodLoss();
    }

    public void startBloodLoss()
    {
        if (repeatCoroutine != null)
        {
            StopCoroutine(repeatCoroutine);
        }
        repeatCoroutine = StartCoroutine(loseBlood());
    }

    private IEnumerator loseBlood()
    {
        while (true)
        {
            yield return new WaitForSeconds(bloodLossInterval);
            health.takeDamage(amountOfBlood);
        }
    }

    public void SetInterval(float newInterval)
    {
        bloodLossInterval = newInterval;
        startBloodLoss();
    }

}
