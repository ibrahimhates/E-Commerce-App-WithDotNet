﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.AddressDtos
{
    public record AddressDto : AddressInsertionDto
    {
        public int UserId { get; init; }
    }
}
