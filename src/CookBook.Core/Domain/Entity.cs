using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.Core.Exceptions;

namespace CookBook.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        protected T Validate<T>(T value, string errorCode, string errorMessage) where T : class
        {
            if (value is null)
            {
                throw new CoreException(errorCode, errorMessage);
            }

            return value;
        }

        protected IEnumerable<T> Validate<T>(IEnumerable<T> value, string  errorCode, string errorMessage) where T : class
        {
            if (value is null || !value.Any())
            {
                throw new CoreException(errorCode, errorMessage);
            }

            return value;
        }

        protected string Validate(string value, string errorCode, string errorMessage)
        {
            if (StringIsEmpty(value))
            {
                throw new CoreException(errorCode, errorMessage);
            }

            return value;
        }

        private bool StringIsEmpty(string value)
            => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }
}