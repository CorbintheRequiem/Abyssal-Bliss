using Unity.VisualScripting;
using UnityEngine;

public class WeldingCrossGame : MonoBehaviour
{
    public GameObject VoltageOrb;
    public GameObject pVoltageOrb;
    public GameObject FlowOrb;
    public GameObject pFlowOrb;

    public float maxSpeed;
    public float minSpeed;
    public float oscY;
    public float oscX;
    public float advancingSpeed;
    public float currentX;

    // Sine Wave Formula: y = 3.4sin(2pix/m)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // It's inverted because the speed is how long it takes to complete an oscilation, not a multiplier.
        oscY = Random.Range(maxSpeed, minSpeed);
        oscX = Random.Range(maxSpeed, minSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Oscilate(VoltageOrb);
        currentX += advancingSpeed * 1/50;
    }

    public void Oscilate(GameObject thing)
    {
        VoltageOrb.transform.position = new Vector3(0, 3.4f * Mathf.Sin(2 * Mathf.PI * currentX / oscY), 0);
        FlowOrb.transform.position = new Vector3(3.4f * Mathf.Sin(2 * Mathf.PI * currentX / oscX), 0, 0);
    }
}
