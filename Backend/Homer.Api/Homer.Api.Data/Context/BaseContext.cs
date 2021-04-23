using System;
using Homer.Api.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Homer.Api.Data.Context
{
    public class BaseContext : DbContext
    {
        private readonly IHttpContextAccessor _iHttpContextAccessor;
        public string _connString {
            get => BaseContextHelpers.GetConnectionStr();
            set {
                BaseContextHelpers.SetConnectionStr(value);
            } 
        }

        public BaseContext(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }

        public string getConnectionString() => _connString;
        
        public BaseContext(string conn) : base()
        {
            _connString = conn;
        }
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        protected MySqlConnection OpenConnection()
        {
            try
            {
                var connectionString = getConnectionString();
                var conn = new MySqlConnection(connectionString); 
                conn.Open();
                return conn;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 17));
            if (!string.IsNullOrWhiteSpace(_connString))
                optionsBuilder.UseMySql(_connString, serverVersion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
