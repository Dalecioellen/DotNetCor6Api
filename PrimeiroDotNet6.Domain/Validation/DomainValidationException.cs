using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroDotNet6.Domain.Validation
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string error) : base(error) // Base cria instancia de exception                                                                      //com uma mensagem de erro específica
        { }

        public static void TemErro(bool existeErro, string mensagemErro)
        {
            if (existeErro)
            {
                throw new DomainValidationException(mensagemErro);
             
            }
           
        }
    }
}
