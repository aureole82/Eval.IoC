using System.Configuration;

namespace Eval.IoC.Common.Services.Implementations
{
    internal class AppSettingsService : ISettingsService
    {
        #region ISettingsService implementation.

        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        #endregion
    }
}