﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.AddressDtos
{
    public record AddressInsertionDto
    {
        public string AddressName { get; init; }
    }
}
