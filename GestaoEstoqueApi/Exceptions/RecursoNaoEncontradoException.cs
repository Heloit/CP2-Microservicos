﻿using System;

namespace GestaoEstoqueApi.Exceptions
{
    public class RecursoNaoEncontradoException : Exception
    {
        public RecursoNaoEncontradoException(string message) : base(message)
        {
        }
    }
}