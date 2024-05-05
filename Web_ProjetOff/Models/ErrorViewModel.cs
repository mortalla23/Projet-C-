using ProjetOfficiel.Models;

namespace Web_ProjetOff.Models
{
    public class ErrorViewModel
    {
        
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
