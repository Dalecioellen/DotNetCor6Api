using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroDotNet6.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultServices<PersonDto>> Create(PersonDto person);

    }
}
