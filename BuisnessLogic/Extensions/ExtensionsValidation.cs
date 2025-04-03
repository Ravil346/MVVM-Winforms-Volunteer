using BuisnessLogic.Models.Request;
using Data;
using Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuisnessLogic.Extensions
{
    public static class ExtensionsValidation
    {
        public static IRuleBuilderOptions<T, Y> PropertyValueMustNotRepeat<T, Y>(this IRuleBuilder<T, Y> ruleBuilder, IEnumerable<Y> objectsInDb, string nameofproerty) where Y : class, new()
        {
            return ruleBuilder.Must(obj => NotRepeat(obj, objectsInDb, nameofproerty)).WithMessage("The obj is repeat");
        }
        public static IRuleBuilderOptions<T, string?> IsValidEmail<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder.Must(IsEmail).WithMessage("This is not a valid e-mail address.");
        }
        public static IRuleBuilderOptions<T, IList<TElement>> ListMatchesType<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, TypeModule typeOfModule) where TElement : Aim
        {
            return ruleBuilder.Must(x => MatchesType(typeOfModule, (IList<Aim>)x));
        }
        private static bool NotRepeat<Y>(Y obj, IEnumerable<Y> objs, string nameofproperty) where Y : class, new()
        {
            var property = obj.GetType().GetProperty(nameofproperty);
            if (property is null) throw new NotImplementedException(nameof(property));
            var userValue = property.GetValue(obj);
            var counter = 0;
            foreach (var item in objs)
            {
                var value = property.GetValue(item);
                if (value == userValue) counter++;
            }
            if (counter == 1) return true;
            return false;
        }
        private static bool IsEmail(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(value, emailPattern);
        }
        private static bool MatchesType(TypeModule type, IList<Aim> tasks)
        {
            bool redflag = true;
            if (type is TypeModule.Theoretical)
            {
                foreach (var task in tasks)
                {
                    if (task.Content!.TypeInput != TypeInput.None |
                        (task.Content.ConfusingAnswers is not null && task.Content.ConfusingAnswers.Count != 0))
                    {
                        redflag = false;
                    }
                }
            }
            if (type is TypeModule.Test)
            {
                foreach (var task in tasks)
                {
                    if (task.Content!.TypeInput == TypeInput.None | (task.Content.ConfusingAnswers is null || task.Content.ConfusingAnswers.Count == 0))
                    {
                        redflag = false;
                    }
                }
            }
            return redflag;
        }
    }
}
