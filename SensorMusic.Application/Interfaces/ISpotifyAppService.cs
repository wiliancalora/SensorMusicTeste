using SensorMusic.Domain.DTO;
using SensorMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SensorMusic.Application.Interfaces
{
    public interface ISpotifyAppService
    {
        Task<SpotifyList> GetPlayListAsync(string genre);
    }
}
