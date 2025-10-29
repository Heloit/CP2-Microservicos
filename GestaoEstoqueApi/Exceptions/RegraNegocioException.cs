using System;

namespace GestaoEstoqueApi.Exceptions
{
    public class RegraNegocioException : Exception
    {
        public RegraNegocioException(string message) : base(message)
        {
        }
    }
}