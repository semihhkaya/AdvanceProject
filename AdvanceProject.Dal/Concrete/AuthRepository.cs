﻿using AdvanceProject.Core.Entities;
using AdvanceProject.Dal.Abstract;
using AdvanceProject.Dal.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Concrete
{
	public class AuthRepository : BaseRepository, IAuthRepository
	{
		public AuthRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
		{
		}
		public async Task<Employee> Register(Employee employee, string password)
		{

			byte[] passHash, passSalt;
			CreatePassword(password, out passHash, out passSalt);

			var sqlquery = "Insert into Employee (Name,Surname,PhoneNumber,Email,PasswordHash,PasswordSalt,BusinessUnitID,TitleID,UpperEmployeeID) Values (@Name,@Surname,@PhoneNumber,@Email,@PasswordHash,@PasswordSalt,@BusinessUnitID,@TitleID,@UpperEmployeeID)";
			
			var parameters = new DynamicParameters();

			parameters.Add("@Name", employee.Name, DbType.String);
			parameters.Add("@Surname", employee.Surname, DbType.String);
			parameters.Add("@PhoneNumber", employee.PhoneNumber, DbType.String);
			parameters.Add("@Email", employee.Email, DbType.String);
			parameters.Add("@PasswordHash", passHash, DbType.Binary);
			parameters.Add("@PasswordSalt", passSalt, DbType.Binary);
			parameters.Add("@BusinessUnitID", employee.BusinessUnitId, DbType.Int32);
			parameters.Add("@TitleID", employee.TitleId, DbType.Int32);
			parameters.Add("@UpperEmployeeID", employee.UpperEmployeeId, DbType.Int32);
			
			var rowsAffected =  await Connection.ExecuteAsync(sqlquery, parameters, Transaction);

			return rowsAffected > 0 ? employee : null;
		}

		public async Task<Employee> Login(string email, string password)
		{
			
			var sqlquery = "SELECT * FROM Employee WHERE Email = @Email";
			var parameters = new DynamicParameters();
			parameters.Add("@Email", email, DbType.String);

			var user = await Connection.QueryFirstOrDefaultAsync<Employee>(sqlquery, parameters, Transaction);

			// Kullanıcı bulunamazsa veya şifre kontrolü başarısızsa null döndür
			if (user == null || !PasswordControl(password, user.PasswordSalt, user.PasswordHash))
			{
				return null;
			}
			
			return user;
		}

		private bool PasswordControl(string password, byte[] passSalt, byte[] passwordHash)
		{
			using (var hmac = new HMACSHA512(passSalt))
			{
				var _passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
				for (int i = 0; i < _passwordHash.Length; i++)
				{
					if (passwordHash[i] != _passwordHash[i])
					{
						return false;
					}

				}
				return true;
			}
		}

		private void CreatePassword(string password, out byte[] passHash, out byte[] passSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
				passSalt = hmac.Key;

			}
		}

		

	}
}
