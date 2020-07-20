using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }
    internal Keep Get(int id, string userId)
    {
      Keep foundKeep = Get(id);
      if (foundKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      if (foundKeep.IsPrivate == true && foundKeep.UserId == userId)
      {
        return foundKeep;
      }
      else if (foundKeep.IsPrivate == false)
      {
        return foundKeep;
      }
      throw new Exception("wow");
    }
    private Keep Get(int id)
    {
      Keep foundKeep = _repo.GetById(id);
      if (foundKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundKeep;
    }

    public Keep Create(Keep newKeep)
    {

      return _repo.Create(newKeep);
    }

    internal Keep Edit(Keep keepToUpdate)
    {
      Keep original = Get(keepToUpdate.Id);
      if (keepToUpdate.UserId == original.UserId)
      {
        return _repo.EditAll(keepToUpdate);
      }
      original.IsPrivate = keepToUpdate.IsPrivate;
      original.Keeps = keepToUpdate.Keeps > 0 ? keepToUpdate.Keeps : original.Keeps;
      original.Shares = keepToUpdate.Shares > 0 ? keepToUpdate.Keeps : original.Keeps;
      original.Views = keepToUpdate.Views > 0 ? keepToUpdate.Keeps : original.Keeps;
      return _repo.Edit(original);

    }



    internal string Delete(int id, string userId)
    {
      Keep foundKeep = Get(id, userId);
      if (foundKeep.UserId != userId)
      {
        throw new Exception("This is not your keep!");
      }
      if (_repo.Delete(id, userId))
      {
        return "sucessfully Deleted";
      }
      throw new Exception("you broke it...");


    }
  }
}