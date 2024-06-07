using UnityEngine;

[CreateAssetMenu(fileName ="CostData")]
public class Cost : ScriptableObject
{
    [SerializeField] int[] cost; 

    public int GetCost(int index)
    {
        if (index >= cost.Length)
        {
            Debug.LogError("to much cost");
            return 0;
        }

        return cost[index];
    }
}
