using GreenLight.DX.Config.Shared.Models;
using GreenLight.DX.Config.Shared.Services;
using System;
using System.Activities;
using System.Activities.DesignViewModels;
using System.Activities.ViewModels.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Shared.Activities;

namespace GreenLight.DX.Config.Activities.ViewModels
{
    public class ConfigurationDynamicDataSourceBuilder : IDynamicDataSourceBuilder
    {
        private readonly GreenLight.DX.Config.Shared.Services.IConfigurationService _configurationService;
        private readonly Project _project;
        private IDataSourceConfigured<Configuration> _dataSourceConfig;
        private DataSource<Configuration> _dataSource;

        public ConfigurationDynamicDataSourceBuilder(GreenLight.DX.Config.Shared.Services.IConfigurationService service)
        {
            _configurationService = service;
            _project = _configurationService.ReadConfigurations();
            ConfigureDataSource();
        }
        public ConfigurationDynamicDataSourceBuilder(string root, string file)
        {
            //_configurationService = new ConfigurationService(root, file);
            _project = _configurationService.ReadConfigurations();
            ConfigureDataSource();
        }
        public async ValueTask<IDataSource> GetDynamicDataSourceAsync(string searchText, int limit, int skip, CancellationToken ct = default)
        {
            try
            {
                IEnumerable<Configuration> configurations = Enumerable.Empty<Configuration>();
                if (_configurationService != null)
                    configurations = _configurationService.ReadConfigurations().Configurations;
                this._dataSource.Data = configurations
                    .Where(configurations => configurations.Name.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
                    .Skip(skip)
                    .Take(limit)
                    .ToList();
                return (IDataSource)this._dataSource;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.StackTrace);
            }
            this._dataSource.Data = Array.Empty<Configuration>();
            return (IDataSource)this._dataSource;
        }

        [Obsolete("Please use the override that supports pagination!")]
        public ValueTask<IDataSource> GetDynamicDataSourceAsync(string searchText, int limit, CancellationToken ct = default)
        {
            return this.GetDynamicDataSourceAsync(searchText, limit, 0, ct);
        }

        public void ConfigureDataSource()
        {
            this._dataSourceConfig = DataSourceBuilder<Configuration>
                .WithId((Func<Configuration, string>)(x => x.Id.ToString()))
                .WithLabel((Func<Configuration, string>)(x => x.Name))
                .WithSingleItemConverter<InArgument<string>>(
                    (Func<Configuration, InArgument<string>>)(s => new InArgument<string>(s.Name)),
                    (Func<InArgument<string>, Configuration>)(s => _project.Configurations.FirstOrDefault(c => c.Id.ToString() == InArgumentExtensions.GetArgumentLiteralValue(s))));
            this._dataSource = this._dataSourceConfig.Build();
        }
    }
}
