using System.Collections.Generic;
using CookBook.Core.Exceptions;

namespace CookBook.Core.Domain
{
    public class RecipeCategory : Entity
    {
        public string Name { get; private set; }

        protected RecipeCategory()
        {
        }

        private RecipeCategory(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
            => Name = Validate(name, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyCategoryName);


    }
}