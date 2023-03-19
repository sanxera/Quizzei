namespace QZI.ReaderOcr.Worker.Domain.Abstractions.Entities;

public abstract class OcrEntity
{
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
}