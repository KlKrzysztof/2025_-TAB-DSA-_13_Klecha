using Shared.Models.Manufacturer;

namespace Shared.Models.Vehicle;

public class VehicleDetailsModel
{
    public int VehicleId { get; set; }

    public Vehicle? Vehicle { get; set; }

    public VehicleModel? VehicleModel { get; set; }

    public ManufacturerModel? VehicleManufacturer { get; set; }

    public VehicleOutfitting? VehicleOutfitting { get; set; }

    public VehiclePurpose? VehiclePurpose { get; set; }

    public VehicleVersion? VehicleVersion { get; set; }
}
