using SensorMusic.Application.Interfaces;
using SensorMusic.Domain.DTO;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SensorMusic.Application
{
    public class SpotifyAppService: ISpotifyAppService
    {
        readonly ISpotifyService _spotifyService;
        readonly IUserAppService _userAppService;

        public SpotifyAppService(ISpotifyService spotifyService,
                                 IUserAppService userAppService)
        {
            _spotifyService = spotifyService;
            _userAppService = userAppService;           
        }

        public Task<SpotifyList> GetPlayListAsync(string genre)
        {
            return _spotifyService.GetPlayListAsync(genre);
        }
    }
}
