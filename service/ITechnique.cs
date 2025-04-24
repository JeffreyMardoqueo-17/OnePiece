using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePieceWorld.Models;

namespace OnePieceWorld.service
{
    public interface ITechnique
    {
        Task<List<Technique>> GetAsyncTechniques();
    }
}