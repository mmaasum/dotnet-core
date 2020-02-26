using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class UtentiOptimizedDto
    {
        public string UteId { get; set; }
        public string UteNome { get; set; }

        public UtentiOptimizedDto MapUtentiToOptimizedDto(Utenti utenti)
        {
            UtentiOptimizedDto utentiOptimizedDto = new UtentiOptimizedDto();
            utentiOptimizedDto.UteId = utenti.UteId;
            utentiOptimizedDto.UteNome = utenti.UteNome;
            return utentiOptimizedDto;
        }
    }
}
