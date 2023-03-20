using UpSchool.Domain.Common;
using UpSchool.Domain.Services;

namespace UpSchool.Wasm.Common.Utilities
{
    public class ToasterLogger:LoggerBase

        
    {
        private readonly IToasterService _toastService;
        public ToasterLogger(IToasterService toastService,string apiUrl):base(apiUrl)
        {
            _toastService = toastService;
        }

        public override void Log(string message)
        {
         //   base.Log(message); base deki log console a logluyprdu
         //başka yere loglamak istersem override işlemi kullanabilirim

            _toastService.ShowSuccess(message);
            base.Log(message);
        }
    }
}
