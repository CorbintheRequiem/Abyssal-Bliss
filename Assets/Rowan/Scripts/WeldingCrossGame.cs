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
    [SerializeField] private float timeX = 0;
    [SerializeField] private float timeY = 0;

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

        // Timer
        timeX += 0.02f;
        timeY += 0.02f;
        if (timeX >= oscX)
        {
            timeX = 0;
            oscX = Random.Range(maxSpeed, minSpeed);
        }
        if (timeY >= oscY)
        {
            timeY = 0;
            oscY = Random.Range(maxSpeed, minSpeed);
        }
    }

    public void Oscilate(GameObject thing)
    {
        VoltageOrb.transform.position = new Vector3(0, 3.4f * Mathf.Sin(2 * Mathf.PI * currentX / oscY), 0);
        FlowOrb.transform.position = new Vector3(3.4f * Mathf.Sin(2 * Mathf.PI * currentX / oscX), 0, 0);
    }
}
