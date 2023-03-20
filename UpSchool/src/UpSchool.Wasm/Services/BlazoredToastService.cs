using System.Security.Cryptography.X509Certificates;
using UpSchool.Domain.Services;

namespace UpSchool.Wasm.Services
{
    public class BlazoredToastService : IToasterService
    {
        private readonly IToasterService _toasterService;
        public void ShowSuccess(string message)
        {
            _toasterService.ShowSuccess(message);
        }

        public void ShowError(string message)
        {
           _toasterService.ShowError(message);
        }

        public BlazoredToastService(IToasterService toasterService)
        {
            _toasterService = toasterService;
        }
    }
}
