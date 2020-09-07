public interface IReceourceAddition<EnumType, T>
{
    void AddReceource(EnumType type, T t = default);

    void ChangeConsumptionAmountSeeds(T amount);

    void ChangeConsumptionTimeSeeds(T amount);

    void ChangeConsumptionAmountWater(T amount);

    void ChangeConsumptionTimeWater(T amount);

}
