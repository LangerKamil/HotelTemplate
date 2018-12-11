using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using HotelApplication.Models;

namespace HotelApplication.EntityValidations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty();

            RuleFor(c => c.IDNumber)
                .NotEmpty();

        }
    }
}