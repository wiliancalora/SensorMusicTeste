using SensorMusic.Domain.DTO;
using SensorMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SensorMusic.Domain.Interfaces.Services
{
    public interface ISpotifyService
    {
        Task<SpotifyList> GetPlayListAsync(string genre);
    }
}
