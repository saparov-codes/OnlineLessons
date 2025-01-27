using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamVariant1.Services.DTOs;

namespace ExamVariant1.Services.Extensions;

public static class MusicDtoExtensions
{
    public static double GetMusicKB(this MusicDto music)
    {
        return music.MB * 1024;
    }

    public static int GetTotalLikes(this List<MusicDto> musicList)
    {
        var total = 0;
        foreach(var music in musicList)
        {
            total += music.QuentityLikes;
        }

        return total;
    }
}

