using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps";
      return _db.Query<Keep>(sql);
    }
    internal Keep GetById(int id)
    {
      string sql = @"
     SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    internal Keep GetPrivate(int id, string userId)
    {
      string sql = @"
      SELECT * FROM keeps WHERE id = @id
      AND userId = @userId;";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id, userId });
    }

    internal Keep Create(Keep KeepData)
    {
      string sql = @"
            INSERT INTO keeps 
            (userId, name, description, img, isPrivate, views, shares, keeps, userEmail)
            VALUES
            (@UserId, @Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps, @UserEmail);
            SELECT LAST_INSERT_ID()";
      KeepData.Id = _db.ExecuteScalar<int>(sql, KeepData);
      return KeepData;
    }

    internal Keep EditAll(Keep original)
    {
      string sql = @"
      UPDATE keeps
      SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = IsPrivate,
        views = @Views,
        shares = @Shares,
        keeps = @Keeps
      WHERE id = @Id and userId = @UserId";
      return _db.QueryFirstOrDefault<Keep>(sql, original);
    }

    internal Keep Edit(Keep original)
    {
      string sql = @"
      UPDATE keeps
      SET
            views = @Views,
            shares = @Shares,
            keeps = @keeps
    WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, original);
    }

    internal bool Delete(int id, string userId)
    {
      string sql = @"
      DELETE FROM keeps WHERE id = @id AND userId = @userId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }
  }
}