namespace Application.Features.ObjectModels.Dtos;

public class CreateDataDto
{
    public required string Year { get; set; }
    public required string Price { get; set; }
    public required string CpuModel { get; set; }
    public required string HardDiskSize { get; set; }
}
