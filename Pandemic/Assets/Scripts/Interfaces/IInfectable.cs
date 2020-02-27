public enum InfectionStatus : byte
{
    Healthy,
    Incubating,
    Curing,
    Infected,
    Cured
}

public interface IInfectable
{
    void Infect();

    void Cure();
}