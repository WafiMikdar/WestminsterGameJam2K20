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
    void Infect(Experience source);

    void Cure(Experience source);
}