using UnityEngine;
using System.Collections.Generic;

public enum FlowBuffType
{
    BallControl,
    MovementSpeed,
    ShootingPrecision,
    TackleStrength,
    CreativePassing
}

public class FlowStateBuff
{
    public FlowBuffType buffType;
    public float percentBoost; // 5% to 75%
    public float duration; // In seconds
}

public class FlowState
{
    public string flowStateName;
    public float bufferDuration;
    public List<FlowStateBuff> activeBuffs;
}

public class FlowStateSystem : MonoBehaviour
{
    [SerializeField] private float flowActivationThreshold = 0.35f; // 35%
    [SerializeField] private float flowBar = 0f;
    [SerializeField] private float maxFlow = 1f;
    [SerializeField] private bool flowActive = false;

    private FlowState currentFlowState;
    private float flowDuration = 0f;
    private List<FlowStateBuff> selectedBuffs = new List<FlowStateBuff>();

    private void Update()
    {
        if (flowActive)
        {
            UpdateFlowDuration();
        }
    }

    public void AddFlow(float amount)
    {
        flowBar = Mathf.Min(flowBar + amount, maxFlow);
    }

    public bool CanActivateFlow()
    {
        return flowBar >= flowActivationThreshold;
    }

    public void ActivateFlow()
    {
        if (!CanActivateFlow())
            return;

        // Spin wheel for buff selection
        SelectRandomBuffs();
        ApplyBuffs();
        flowActive = true;
        flowDuration = GetMaxBuffDuration();
    }

    private void SelectRandomBuffs()
    {
        selectedBuffs.Clear();
        int buffCount = Random.Range(1, 5); // 1-4 random attributes

        for (int i = 0; i < buffCount; i++)
        {
            FlowStateBuff buff = new FlowStateBuff
            {
                buffType = (FlowBuffType)Random.Range(0, 5),
                percentBoost = Random.Range(0.05f, 0.75f) * 100f, // 5% to 75%
                duration = Random.Range(10f, 30f) // 10-30 seconds
            };
            selectedBuffs.Add(buff);
        }
    }

    private void ApplyBuffs()
    {
        foreach (var buff in selectedBuffs)
        {
            ApplyBuffToPlayer(buff);
        }
    }

    private void ApplyBuffToPlayer(FlowStateBuff buff)
    {
        // Implementation would apply to actual player controller
        switch (buff.buffType)
        {
            case FlowBuffType.BallControl:
                // Increase ball control accuracy
                break;
            case FlowBuffType.MovementSpeed:
                // Increase player speed
                break;
            case FlowBuffType.ShootingPrecision:
                // Increase shot accuracy
                break;
            case FlowBuffType.TackleStrength:
                // Increase tackle effectiveness
                break;
            case FlowBuffType.CreativePassing:
                // Enable special pass types
                break;
        }
    }

    private void UpdateFlowDuration()
    {
        flowDuration -= Time.deltaTime;
        if (flowDuration <= 0f)
        {
            DeactivateFlow();
        }
    }

    private void DeactivateFlow()
    {
        flowActive = false;
        flowBar = 0f;
        selectedBuffs.Clear();
        // Remove buffs from player
    }

    private float GetMaxBuffDuration()
    {
        float maxDuration = 0f;
        foreach (var buff in selectedBuffs)
        {
            maxDuration = Mathf.Max(maxDuration, buff.duration);
        }
        return maxDuration;
    }

    public float GetFlowPercentage()
    {
        return (flowBar / maxFlow) * 100f;
    }

    public List<FlowStateBuff> GetSelectedBuffs()
    {
        return selectedBuffs;
    }
}
