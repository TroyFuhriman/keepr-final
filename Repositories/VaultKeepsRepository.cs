using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }
    internal IEnumerable<VaultKeepViewModel> GetByUserId(string userId)
    {
      string sql = @"
      SELECT 
      k.*,
      vk.id as vaultKeepId
      FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE userId = @userId;";
      return _db.Query<VaultKeepViewModel>(sql, new { userId });
    }
    internal bool hasRelationship(VaultKeep newVaultKeep)
    {
      string sql = "SELECT * FROM vaultKeeps WHERE keepId = @KeepId and userId = @UserId";
      var found = _db.QueryFirstOrDefault<VaultKeep>(sql, newVaultKeep);
      return found != null;
    }
    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (userId, keepId, vaultId)
      VALUES
      (@UserId, @KeepId, @VaultId);
      SELECT LAST_INSERT_ID();";
      newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
    {
      string sql = @"
      SELECT 
        k.*,
        vk.id as vaultKeepId
        FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId 
        WHERE (vaultId = @vaultId AND vk.userId = @userId) ";
      return _db.Query<VaultKeepViewModel>(sql, new { vaultId, userId });
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id and userId = @userId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }
  }
}