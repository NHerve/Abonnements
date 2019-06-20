using MagGestion.DataServices.Interface;
using MagGestion.Forms.Interface;
using MagGestion.Helper.Interface;
using RestSharp.Deserializers;

namespace MagGestion.Presenter
{
    public class BasePresenter
    {
        protected readonly IFormOpener _formOpener;
        protected readonly ICacheService _cache;
        protected readonly IErrorLogger _errorLogger;
        protected readonly IDeserializer _serializer;
        public BasePresenter(IFormOpener formOpener, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer)
        {
            _formOpener = formOpener;
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
        }
        public BasePresenter(ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer)
        {
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
        }
    }
}
