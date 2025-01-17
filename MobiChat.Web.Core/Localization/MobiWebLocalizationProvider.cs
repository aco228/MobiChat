﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Senti.Localization;
using MobiChat.Data;

namespace MobiChat.Web.Core.Localization
{
  public class MobiWebLocalizationProvider : LocalizationProviderBase<MobiChatWebLocalization>
  {
    private MobiChat.Data.Localization _localization = null;
    private Translation _translation = null;
    private Product _product = null;

		public Product Product { get { return this._product ?? this._localization.Product; } }
		public Translation Translation { get { return this._translation ?? this._localization.Translation; } }
		public MobiChat.Data.Localization Localization { get { return this._localization; } }

    
		public MobiWebLocalizationProvider(Translation translation)
		{
			this._translation = translation;
		}

    public MobiWebLocalizationProvider(MobiChat.Data.Localization localization) 
		{
			this._localization = localization;
			this._product = localization.Product;
			this._translation = localization.Translation;
		}

    public override void UpdateSource(IEnumerable<LocalizedContent> localizedContent)
		{
			foreach (LocalizedContent lk in localizedContent)
			{
				TranslationKey key = lk.LocalizationKey as TranslationKey;
				TranslationGroupKey groupKey = TranslationGroupKey.CreateManager(2).Load(key.Translation, lk.Group, lk.Key);
				TranslationValue existingValue = TranslationValue.CreateManager().Load(lk.LocalizationKey as TranslationKey, groupKey);
				if (existingValue != null)
				{
					if (lk.Value == null)
					{
						existingValue.Delete();
					}
					else if (!existingValue.Value.Equals(lk.Value))
					{
						existingValue.Value = lk.Value;
						existingValue.Update();
					}
				}
				else if (lk.Value != null)
				{
					TranslationValue newValue = new TranslationValue(-1, key, groupKey, lk.Value, DateTime.Now, DateTime.Now);
					newValue.Insert();
				}
			}
		}

		protected override IEnumerable<ILocalizationKey> LoadLocalizationKeys()
		{
      return (from TranslationKey key in (TranslationKey.CreateManager(3).Load(this.Translation))
							select key);
		}

		protected override IEnumerable<LocalizationGroupKey> LoadLocalizationGroupKeys()
		{
			return (from TranslationGroupKey t in (TranslationGroupKey.CreateManager(3).Load(this.Translation))
							select new LocalizationGroupKey(t.TranslationGroup.Translation.Name,
																							t.TranslationGroup.Name, t.Name, t.Comment));
		}

		protected override IEnumerable<LocalizedContent> LoadLocalizedContent()
		{
      return (from TranslationValue t in (TranslationValue.CreateManager(3).Load(this.Translation))
							select new LocalizedContent(t.TranslationKey, t.TranslationGroupKey.TranslationGroup.Name,
																					t.TranslationGroupKey.Name, t.Value));
		}

  }
}
