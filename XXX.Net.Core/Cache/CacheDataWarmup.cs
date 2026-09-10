using XXX.Net.Core.Entity.Sys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace XXX.Net.Core.Cache
{
    public class CacheDataWarmup : ICacheWarmup
    {
        private readonly ICacheService _cacheService;
        private readonly IMSRepository _msRepository;
        private readonly EnumScanner _enumScanner;
        public CacheDataWarmup(
            ICacheService cacheService, IMSRepository msRepository, EnumScanner enumScanner)
        {
            _cacheService = cacheService;
            _msRepository = msRepository;
            _enumScanner = enumScanner;
        }
        public int Order => 10;

        public async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            await InitSysConfigAsync();
            await InitEnumDataAsync();
            await InitDictDataAsync();
        }

        public async Task InitEnumDataAsync(string key = "Sys_EnumData")
        {
            var result = _enumScanner.Scan();
            await _cacheService.SetAsync(key, result);

        }

        public async Task InitSysConfigAsync(string key = "Sys_ConfigData")
        {
            var mlSysConfig = await _msRepository.Slave<SysConfig>().AsQueryable().ToListAsync();
            var configs = mlSysConfig.Select(s => s.Adapt<ConfigCache>());
            await _cacheService.SetAsync(key, configs);
        }

        public async Task InitDictDataAsync(string key = "Sys_DictData")
        {


            var dictTypes = await _msRepository
            .Slave<SysDictType>()
            .Include(x => x.Children)
            .ToListAsync();

            var dict = dictTypes
                .Where(x => !string.IsNullOrWhiteSpace(x.Code))
                .ToDictionary(
                    x => x.Code,
                    x => x.Children
                        .Where(w => w.Enabled)
                        .Select(s => s.Adapt<PagedOptions>())
                        .ToList());

            await _cacheService.SetAsync(key, dict);
        }

    }
}
