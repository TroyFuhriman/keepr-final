using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Vault> Get(string userId)
    {
      string sql = "SELECT * FROM vaults WHERE userId = @userId";
      return _db.Query<Vault>(sql, new { userId });
    }

    internal Vault GetById(int id, string userId)
    {
      string sql = @"
      SELECT * FROM vaults WHERE id = @Id AND userId = @userId";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id, userId });
    }

    internal Vault GetById(int id)
    {
      string sql = @"
      SELECT * FROM vaults WHERE id = @Id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }

    internal Vault Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO vaults
      (userId, name, description)
      VALUES
      (@UserID, @Name, @Description);
      SELECT LAST_INSERT_ID()";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return newVault;
    }

    internal Vault Edit(Vault vaultUpdate)
    {
      string sql = @"
      UPDATE vaults
      SET
        name =@Name,
        description = @Description,
    WHERE id = @Id";
      return _db.QueryFirstOrDefault<Vault>(sql, vaultUpdate);
    }

    internal bool Delete(int id, string userId)
    {
      string sql = @"
     DELETE FROM vaults WHERE id = @id AND userId = userId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }
  }
}