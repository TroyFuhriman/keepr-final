using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Keepr.Models;

namespace keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<VaultKeepViewModel> Get(string userId)
    {
      return _repo.GetByUserId(userId);
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      if (_repo.hasRelationship(newVaultKeep))
      {
        throw new Exception("you already have that in your vault");
      }
      return _repo.Create(newVaultKeep);
    }
    private VaultKeep GetById(int id)
    {
      VaultKeep found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("invalid Id");
      }
      return found;
    }
    internal VaultKeep Delete(string userId, int id)
    {
      VaultKeep found = GetById(id);
      if (found.UserId != userId)
      {
        throw new Exception("this is not yours!");
      }
      if (_repo.Delete(id, userId))
      {
        return found;
      }
      throw new Exception("something bad happened");
    }

    internal IEnumerable<VaultKeep> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _repo.GetKeepsByVaultId(vaultId, userId);
    }
  }
}