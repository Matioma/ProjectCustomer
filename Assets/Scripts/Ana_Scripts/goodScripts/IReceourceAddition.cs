using Unity;
using System.Collections;
using System.Collections.Generic;

public interface IReceourceAddition<ResourceType>
{
    void AddReceource(ResourceType type,  int amount);
    void ChangeConsumptionAmountSeeds(int amount);
    void ChangeConsumptionTimeSeeds(int amount);
    void ChangeConsumptionAmountWater(int amount);
    void ChangeConsumptionTimeWater(int amount);

}
