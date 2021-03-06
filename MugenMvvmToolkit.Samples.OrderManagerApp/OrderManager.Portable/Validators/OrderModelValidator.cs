﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MugenMvvmToolkit.Infrastructure.Validation;
using OrderManager.Portable.Models;

namespace OrderManager.Portable.Validators
{
    public class OrderModelValidator : ValidatorBase<OrderModel>
    {
        #region Overrides of ValidatorBase

        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(string propertyName, CancellationToken token)
        {
            var dictionary = new Dictionary<string, IEnumerable>();
            if (MemberNameEqual(propertyName, () => model => model.Name))
                ValidateName(propertyName, dictionary);
            else if (MemberNameEqual(propertyName, () => model => model.Number))
                ValidateNumber(propertyName, dictionary);
            return FromResult(dictionary);
        }

        protected override Task<IDictionary<string, IEnumerable>> ValidateInternalAsync(CancellationToken token)
        {
            var dictionary = new Dictionary<string, IEnumerable>();
            ValidateNumber(GetMemberName(() => model => model.Number), dictionary);
            ValidateName(GetMemberName(() => model => model.Name), dictionary);
            return FromResult(dictionary);
        }

        #endregion

        #region Methods

        private void ValidateNumber(string key, IDictionary<string, IEnumerable> dictionary)
        {
            dictionary[key] = string.IsNullOrEmpty(Instance.Number)
                ? string.Format(UiResources.RequiredFieldErrorMessageFormat, key)
                : null;
        }

        private void ValidateName(string key, IDictionary<string, IEnumerable> dictionary)
        {
            dictionary[key] = string.IsNullOrEmpty(Instance.Name)
                ? string.Format(UiResources.RequiredFieldErrorMessageFormat, key)
                : null;
        }

        #endregion
    }
}