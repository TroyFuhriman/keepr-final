using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Vault> Get(string userId)
    {
      return _repo.Get(userId);
    }

    internal Vault Get(int id, string userId)
    {
      Vault foundVault = _repo.GetById(id, userId);
      if (foundVault == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundVault;
    }
    internal Vault Get(int id)
    {
      Vault foundVault = _repo.GetById(id);
      if (foundVault == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundVault;
    }

    internal Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    internal Vault Edit(Vault vaultUpdate)
    {
      Vault original = Get(vaultUpdate.Id);
      if (vaultUpdate.UserId == original.UserId)
      {
        return _repo.Edit(vaultUpdate);
      }
      throw new Exception("This is not your Vault!");
    }

    internal string Delete(int id, string userId)
    {
      Vault foundVault = Get(id);
      if (foundVault.UserId != userId)
      {
        throw new Exception("This is not your Vault!");
      }
      if (_repo.Delete(id, userId))
      {
        return "sucessfully Deleted";
      }
      throw new Exception("you broke it...");
    }
  }
}