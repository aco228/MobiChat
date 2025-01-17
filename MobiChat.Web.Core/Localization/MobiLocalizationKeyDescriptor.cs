﻿using MobiChat.Data;
using Senti.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core
{
  class MobiLocalizationKeyDescriptor : LocalizationKeyDescriptor
  {
    public MobiLocalizationKeyDescriptor()
			: base(3)
		{

		}

		public override string[] GetKeyNames(ILocalizationKey key)
		{
			//return new string[] { "Product", "Language", "Service" };
			return new string[] { "TranslationKey", "Language", "Service" };
		}

		public override string[] GetKeyValues(ILocalizationKey key)
		{

			TranslationKey translationKey = key as TranslationKey;
			if(translationKey == null)
				throw new InvalidCastException("Argument 'key' must be of type TranslationKey to be used in conjunction with 'ClipmobileLocalizationKeyDescriptor'.");
			return new string[] { translationKey.ID.ToString(), 
                            translationKey.Language == null ? string.Empty : translationKey.Language.TwoLetterIsoCode,
                            translationKey.Service == null ? string.Empty : translationKey.Service.Name };
		}

		public override ILocalizationKey GetKey(string[] values)
		{
			if (values.Length < 3)
				return null;
			//string productName = values[0];
			//if (string.IsNullOrEmpty(productName))
			//	return null;
			//
			//string localizationId = values[0];
			//if (string.IsNullOrEmpty(localizationId))
			//	return null;
			//Data.Localization localization = Data.Localization.CreateManager().Load(Int32.Parse(localizationId));
			//
			//Product product = Product.CreateManager().Load(productName);
			//if (product == null)
			//	return null;
			//Translation translation = Translation.CreateManager().Load<Translation>(product);

			string translationKeyId = values[0];
			if (string.IsNullOrEmpty(translationKeyId))
				return null;
			TranslationKey tk = TranslationKey.CreateManager().Load(Int32.Parse(translationKeyId));

			Translation translation = tk.Translation;
			if (translation == null)
				return null;
			string languageCode = values[1];
			Language language = null;
			if (!string.IsNullOrEmpty(languageCode))
				language = Language.CreateManager().Load(languageCode, LanguageIdentifier.TwoLetterIsoCode);
			string serviceName = values[2];
			Service service = null;
			if (!string.IsNullOrEmpty(serviceName))
				service = Service.CreateManager().Load(serviceName);

			return new TranslationKey(translation, language, service);
		}
  }
}
