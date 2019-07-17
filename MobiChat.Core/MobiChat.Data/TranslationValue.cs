using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

 

namespace MobiChat.Data 
{
  public partial interface ITranslationValueManager 
  {

    
    TranslationValue Load(TranslationValue translationValue);
    TranslationValue Load(IConnectionInfo connection, TranslationValue translationValue);


    TranslationValue Load(Translation translation, string translationGroupName, string translationGroupKeyName);
    TranslationValue Load(IConnectionInfo connection, Translation translation, string translationGroupName, string translationGroupKeyName);
    TranslationValue Load(TranslationKey translationKey, TranslationGroupKey translationGroupKey);
    TranslationValue Load(IConnectionInfo connection, TranslationKey translationKey, TranslationGroupKey translationGroupKey);
    List<TranslationValue> Load(Language language);
    List<TranslationValue> Load(IConnectionInfo connection, Language language);
    List<TranslationValue> Load(Service service);
    List<TranslationValue> Load(IConnectionInfo connection, Service service);

    //List<TranslationValue> Load(TranslationKey translationKey, TranslationGroup translationGroup);
    //List<TranslationValue> Load(IConnectionInfo connection, TranslationKey translationKey, TranslationGroup translationGroup);


   


    /// <summary>
    /// Obfuscated!!!
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    List<TranslationValue> Load(Product product);
    List<TranslationValue> Load(IConnectionInfo connection, Product product);
    List<TranslationValue> Load(Translation translation);
    List<TranslationValue> Load(IConnectionInfo connection, Translation translation);

    
    List<TranslationValue> Load(Translation translation, TranslationKey translationKey, TranslationGroup translationGroup);
    List<TranslationValue> Load(IConnectionInfo connection, Translation translation, TranslationKey translationKey, TranslationGroup translationGroup);


  }

  public partial class TranslationValue
  {

    // SUMMARY: This class prepares IF/ELSE conditions in TranslationValues
    public static string Conditions(string text, IService service)
    {
      #region #example#
      /*
        
        {
        [IF[Merchant.Name]=='Centili']- This line will be used in case of mercahtn is cenitli
        [ELSE IF[Service.Name]=='erovids.mobi']- This line will be used in case if service is 'erovids.mobi'
        [ELSE IF[Merchant.Name]!='NTH']- This line will be used if previous conditions are not validated and merchant is not 'NTH'
        [ELSE]- this line will be used in case that previous conditions are not validated
        }

      */
      #endregion

      //if (!text.Contains("{") || !text.Contains("}"))
      //  return text;

      //text = text.Replace("~", "").Replace("\n", "~");

      //// Get all content from block { .* }
      //var bracket_matches = Regex.Matches(text, @"{.*?}");
      //foreach (Match bracket_match in bracket_matches)
      //{
      //  string result = "";
      //  string originalText = bracket_match.Groups[0].ToString();
      //  string removeBrackets = originalText.Replace("{", "").Replace("}", "").Replace("/n", System.Environment.NewLine).Trim();

      //  // REGEX for geting conditions [IF[condition]=='condition_value']-(value)
      //  var conditions_matches = Regex.Matches(originalText, @"(\[.+?\]-\(.+?\))");
      //  foreach (Match conditional_match in conditions_matches)
      //  {
      //    try
      //    {
      //      string match_string = conditional_match.Groups[0].Value;

      //      // REGEX: Value -(value)
      //      string value = ((Regex.Matches(match_string, @"(-\((.+)\))")[0] as Match).Groups[2].Value);
      //      if (match_string.Replace(" ", "").Contains("[ELSE]"))
      //      {
      //        result = value;
      //        break;
      //      }

      //      // REGEX: getting condition and condition value IF[condition]=='condition_value']
      //      string conditional = (Regex.Matches(match_string, @"(\[[A-Za-z]+\.[A-Z][a-z]+\])")[0] as Match).Groups[0].Value;
      //      string conditional_value = ((Regex.Matches(match_string, @"(\'[a-zA-Z\.]+\')")[0] as Match).Groups[0].Value).Replace("'", "");

      //      // CHECK CONDITION
      //      if ((conditional.Equals("[Service.Name]")) &&
      //        (match_string.Contains("==") && service.ServiceData.Name.Equals(conditional_value)) ||
      //          (match_string.Contains("!=") && !service.ServiceData.Name.Equals(conditional_value)))
      //      {
      //        result = value;
      //        break;
      //      }
      //      if ((conditional.Equals("[Service.Type]")) &&
      //        (match_string.Contains("==") && service.ServiceInfo.TemplateServiceType.ToString().Equals(conditional_value)) ||
      //          (match_string.Contains("!=") && !service.ServiceInfo.TemplateServiceType.ToString().Equals(conditional_value)))
      //      {
      //        result = value;
      //        break;
      //      }
      //      else if (conditional.Equals("[Merchant.Name]") &&
      //        (match_string.Contains("==") && service.ServiceData.Merchant.Name.Equals(conditional_value)) ||
      //          (match_string.Contains("!=") && !service.ServiceData.Merchant.Name.Equals(conditional_value)))
      //      {
      //        result = value;
      //        break;
      //      }
      //      else if (conditional.Equals("[PaymentProvider.Name]") &&
      //        (match_string.Contains("==") && service.PaymentProvider.Name.Equals(conditional_value)) ||
      //          (match_string.Contains("!=") && !service.PaymentProvider.Name.Equals(conditional_value)))
      //      {
      //        result = value;
      //        break;
      //      }
      //      else
      //      { }
      //    }
      //    catch (Exception e)
      //    {
      //      break;
      //    }

      //  }

      //  if (!string.IsNullOrEmpty(result))
      //    text = text.Replace(originalText, result.Trim());

      //}

      //return text.Replace("~", "\n");

      return text;
    }

  }
}

