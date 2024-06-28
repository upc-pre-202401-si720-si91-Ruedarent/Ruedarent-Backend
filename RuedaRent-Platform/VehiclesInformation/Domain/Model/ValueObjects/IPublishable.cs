namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.ValueObjects;

public interface IPublishable
{
    void SendToOccupied();

    void SendToDisponible();
}