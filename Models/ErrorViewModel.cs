namespace BeFit.Web.Models; // Upewniamy się, że jest w dobrej "szufladce"

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}