﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            //If you change to other cache manager than Microsoft's you can remove the AddMemoryCache() line from here
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();

            //For performance aspect
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
