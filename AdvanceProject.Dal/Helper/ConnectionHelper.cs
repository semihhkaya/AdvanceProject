﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Helper
{
	public class ConnectionHelper
	{
        private static IConfiguration _configuration = null!;

        /// <summary>
        /// Configuration Settings
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get Configuration
        /// </summary>
        /// <returns></returns>
        public static IConfiguration GetConfiguration()
        {
            return _configuration;
        }

        /// <summary>
        /// Get Configuration Settings Value
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return GetConfiguration().GetSection("ConnectionStrings:dapperConn").Value;
        }
    }
}
