using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePieceWorld.Models;

namespace OnePieceWorld.service
{
    public interface ICrewService
    {
        Task<List<Crew>> GetCrewsAsync();
    }
}