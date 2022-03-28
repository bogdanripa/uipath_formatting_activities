﻿using System;
using System.Activities;
using System.Activities.DesignViewModels;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.BasicTypes.Resources;

namespace UiPathTeam.BasicTypes.ViewModel
{
    /// <summary>
    /// This is the view model for an activity that controls the visibility of properties based on another property.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class GetDateFromTextActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<string> InputText { get; set; }

        public DesignInArgument<string> Culture { get; set; }

        public DesignOutArgument<DateTime> OutDate { get; set; }

        private DataSource<string> _culturesDataSource;
        public GetDateFromTextActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputText.IsPrincipal = true;
            InputText.IsRequired = true;
            InputText.DisplayName = Resource1.GetDateFromText_Property_InputText;

            Culture.IsPrincipal = false;
            Culture.IsRequired = false;
            Culture.DisplayName = Resource1.GetDateFromText_Property_Culture;

            OutDate.IsPrincipal = false;
            OutDate.IsVisible = true;
            OutDate.DisplayName = Resource1.GetDateFromText_Property_OutDate;

            // data source for the dropdown
            _culturesDataSource = DataSourceBuilder<string>
                .WithId(s => s)
                .WithLabel(s => s)
                .WithSingleItemConverter(
                    itemToValue: s => new InArgument<string>(s),
                    valueToItem: s => GetStringValue(s))
                .Build();
            Culture.DataSource = _culturesDataSource;

            Culture.Widget = new DefaultWidget() { Type = "AutoCompleteForExpression" };

            //dropdown values
            _culturesDataSource.Data = new string[835] { "aa", "aa-DJ", "aa-ER", "aa-ET", "af", "af-NA", "af-ZA", "agq", "agq-CM", "ak", "ak-GH", "sq", "sq-AL", "sq-MK", "gsw", "gsw-FR", "gsw-LI", "gsw-CH", "am", "am-ET", "ar", "ar-DZ", "ar-BH", "ar-TD", "ar-KM", "ar-DJ", "ar-EG", "ar-ER", "ar-IQ", "ar-IL", "ar-JO", "ar-KW", "ar-LB", "ar-LY", "ar-MR", "ar-MA", "ar-OM", "ar-PS", "ar-QA", "ar-SA", "ar-SO", "ar-SS", "ar-SD", "ar-SY", "ar-TN", "ar-AE", "ar-001", "ar-YE", "hy", "hy-AM", "as", "as-IN", "ast", "ast-ES", "asa", "asa-TZ", "az-Cyrl", "az-Cyrl-AZ", "az", "az-Latn", "az-Latn-AZ", "ksf", "ksf-CM", "bm", "bm-Latn-ML", "bn", "bn-BD", "bn-IN", "bas", "bas-CM", "ba", "ba-RU", "eu", "eu-ES", "be", "be-BY", "bem", "bem-ZM", "bez", "bez-TZ", "byn", "byn-ER", "brx", "brx-IN", "bs-Cyrl", "bs-Cyrl-BA", "bs-Latn", "bs", "bs-Latn-BA", "br", "br-FR", "bg", "bg-BG", "my", "my-MM", "ca", "ca-AD", "ca-FR", "ca-IT", "ca-ES", "ceb", "ceb-Latn", "ceb-Latn-PH", "tzm-Arab-MA", "tzm-Latn-MA", "ku", "ku-Arab", "ku-Arab-IQ", "ccp", "ccp-Cakm", "ccp-Cakm-BD", "ccp-Cakm-IN", "ce-RU", "chr", "chr-Cher", "chr-Cher-US", "cgg", "cgg-UG", "zh-Hans", "zh", "zh-CN", "zh-SG", "zh-Hant", "zh-HK", "zh-MO", "zh-TW", "cu-RU", "swc", "swc-CD", "kw", "kw-GB", "co", "co-FR", "hr", "hr-HR", "hr-BA", "cs", "cs-CZ", "da", "da-DK", "da-GL", "prs", "prs-AF", "dv", "dv-MV", "dua", "dua-CM", "nl", "nl-AW", "nl-BE", "nl-BQ", "nl-CW", "nl-NL", "nl-SX", "nl-SR", "dz", "dz-BT", "ebu", "ebu-KE", "en", "en-AS", "en-AI", "en-AG", "en-AU", "en-AT", "en-BS", "en-BB", "en-BE", "en-BZ", "en-BM", "en-BW", "en-IO", "en-VG", "en-BI", "en-CM", "en-CA", "en-029", "en-KY", "en-CX", "en-CC", "en-CK", "en-CY", "en-DK", "en-DM", "en-ER", "en-150", "en-FK", "en-FI", "en-FJ", "en-GM", "en-DE", "en-GH", "en-GI", "en-GD", "en-GU", "en-GG", "en-GY", "en-HK", "en-IN", "en-IE", "en-IM", "en-IL", "en-JM", "en-JE", "en-KE", "en-KI", "en-LS", "en-LR", "en-MO", "en-MG", "en-MW", "en-MY", "en-MT", "en-MH", "en-MU", "en-FM", "en-MS", "en-NA", "en-NR", "en-NL", "en-NZ", "en-NG", "en-NU", "en-NF", "en-MP", "en-PK", "en-PW", "en-PG", "en-PN", "en-PR", "en-PH", "en-RW", "en-KN", "en-LC", "en-VC", "en-WS", "en-SC", "en-SL", "en-SG", "en-SX", "en-SI", "en-SB", "en-ZA", "en-SS", "en-SH", "en-SD", "en-SZ", "en-SE", "en-CH", "en-TZ", "en-TK", "en-TO", "en-TT", "en-TC", "en-TV", "en-UG", "en-AE", "en-GB", "en-US", "en-UM", "en-VI", "en-VU", "en-001", "en-ZM", "en-ZW", "eo", "eo-001", "et", "et-EE", "ee", "ee-GH", "ee-TG", "ewo", "ewo-CM", "fo", "fo-DK", "fo-FO", "fil", "fil-PH", "fi", "fi-FI", "fr", "fr-DZ", "fr-BE", "fr-BJ", "fr-BF", "fr-BI", "fr-CM", "fr-CA", "fr-029", "fr-CF", "fr-TD", "fr-KM", "fr-CG", "fr-CD", "fr-CI", "fr-DJ", "fr-GQ", "fr-FR", "fr-GF", "fr-PF", "fr-GA", "fr-GP", "fr-GN", "fr-HT", "fr-LU", "fr-MG", "fr-ML", "fr-MQ", "fr-MR", "fr-MU", "fr-YT", "fr-MA", "fr-NC", "fr-NE", "fr-MC", "fr-RE", "fr-RW", "fr-BL", "fr-MF", "fr-PM", "fr-SN", "fr-SC", "fr-CH", "fr-SY", "fr-TG", "fr-TN", "fr-VU", "fr-WF", "fy", "fy-NL", "fur", "fur-IT", "ff", "ff-Latn", "ff-Latn-BF", "ff-CM", "ff-Latn-CM", "ff-Latn-GM", "ff-Latn-GH", "ff-GN", "ff-Latn-GN", "ff-Latn-GW", "ff-Latn-LR", "ff-MR", "ff-Latn-MR", "ff-Latn-NE", "ff-NG", "ff-Latn-NG", "ff-Latn-SN", "ff-Latn-SL", "gl", "gl-ES", "lg", "lg-UG", "ka", "ka-GE", "de", "de-AT", "de-BE", "de-DE", "de-IT", "de-LI", "de-LU", "de-CH", "el", "el-CY", "el-GR", "kl", "kl-GL", "gn", "gn-PY", "gu", "gu-IN", "guz", "guz-KE", "ha", "ha-Latn", "ha-Latn-GH", "ha-Latn-NE", "ha-Latn-NG", "haw", "haw-US", "he", "he-IL", "hi", "hi-IN", "hu", "hu-HU", "is", "is-IS", "ig", "ig-NG", "id", "id-ID", "ia", "ia-FR", "ia-001", "iu", "iu-Latn", "iu-Latn-CA", "iu-Cans", "iu-Cans-CA", "ga", "ga-IE", "it", "it-IT", "it-SM", "it-CH", "it-VA", "ja", "ja-JP", "jv", "jv-Latn", "jv-Latn-ID", "dyo", "dyo-SN", "kea", "kea-CV", "kab", "kab-DZ", "kkj", "kkj-CM", "kln", "kln-KE", "kam", "kam-KE", "kn", "kn-IN", "kr-Latn-NG", "ks", "ks-Arab", "ks-Arab-IN", "ks-Deva-IN", "kk", "kk-KZ", "km", "km-KH", "quc", "quc-Latn-GT", "ki", "ki-KE", "rw", "rw-RW", "sw", "sw-KE", "sw-TZ", "sw-UG", "kok", "kok-IN", "ko", "ko-KR", "ko-KP", "khq", "khq-ML", "ses", "ses-ML", "nmg", "nmg-CM", "ky", "ky-KG", "ku-Arab-IR", "lkt", "lkt-US", "lag", "lag-TZ", "lo", "lo-LA", "la-VA", "lv", "lv-LV", "ln", "ln-AO", "ln-CF", "ln-CG", "ln-CD", "lt", "lt-LT", "nds", "nds-DE", "nds-NL", "dsb", "dsb-DE", "lu", "lu-CD", "luo", "luo-KE", "lb", "lb-LU", "luy", "luy-KE", "mk", "mk-MK", "jmc", "jmc-TZ", "mgh", "mgh-MZ", "kde", "kde-TZ", "mg", "mg-MG", "ms", "ms-BN", "ms-MY", "ml", "ml-IN", "mt", "mt-MT", "gv", "gv-IM", "mi", "mi-NZ", "arn", "arn-CL", "mr", "mr-IN", "mas", "mas-KE", "mas-TZ", "mzn-IR", "mer", "mer-KE", "mgo", "mgo-CM", "moh", "moh-CA", "mn", "mn-Cyrl", "mn-MN", "mn-Mong", "mn-Mong-CN", "mn-Mong-MN", "mfe", "mfe-MU", "mua", "mua-CM", "nqo", "nqo-GN", "naq", "naq-NA", "ne", "ne-IN", "ne-NP", "nnh", "nnh-CM", "jgo", "jgo-CM", "lrc-IQ", "lrc-IR", "nd", "nd-ZW", "no", "nb", "nb-NO", "nn", "nn-NO", "nb-SJ", "nus", "nus-SD", "nus-SS", "nyn", "nyn-UG", "oc", "oc-FR", "or", "or-IN", "om", "om-ET", "om-KE", "os", "os-GE", "os-RU", "ps", "ps-AF", "ps-PK", "fa", "fa-AF", "fa-IR", "pl", "pl-PL", "pt", "pt-AO", "pt-BR", "pt-CV", "pt-GQ", "pt-GW", "pt-LU", "pt-MO", "pt-MZ", "pt-PT", "pt-ST", "pt-CH", "pt-TL", "prg-001", "qps-ploca", "qps-ploc", "qps-plocm", "pa", "pa-Arab", "pa-IN", "pa-Arab-PK", "quz", "quz-BO", "quz-EC", "quz-PE", "ksh", "ksh-DE", "ro", "ro-MD", "ro-RO", "rm", "rm-CH", "rof", "rof-TZ", "rn", "rn-BI", "ru", "ru-BY", "ru-KZ", "ru-KG", "ru-MD", "ru-RU", "ru-UA", "rwk", "rwk-TZ", "ssy", "ssy-ER", "sah", "sah-RU", "saq", "saq-KE", "smn", "smn-FI", "smj", "smj-NO", "smj-SE", "se", "se-FI", "se-NO", "se-SE", "sms", "sms-FI", "sma", "sma-NO", "sma-SE", "sg", "sg-CF", "sbp", "sbp-TZ", "sa", "sa-IN", "gd", "gd-GB", "seh", "seh-MZ", "sr-Cyrl", "sr-Cyrl-BA", "sr-Cyrl-ME", "sr-Cyrl-RS", "sr-Cyrl-CS", "sr-Latn", "sr", "sr-Latn-BA", "sr-Latn-ME", "sr-Latn-RS", "sr-Latn-CS", "nso", "nso-ZA", "tn", "tn-BW", "tn-ZA", "ksb", "ksb-TZ", "sn", "sn-Latn", "sn-Latn-ZW", "sd", "sd-Arab", "sd-Arab-PK", "si", "si-LK", "sk", "sk-SK", "sl", "sl-SI", "xog", "xog-UG", "so", "so-DJ", "so-ET", "so-KE", "so-SO", "st", "st-ZA", "nr", "nr-ZA", "st-LS", "es", "es-AR", "es-BZ", "es-VE", "es-BO", "es-BR", "es-CL", "es-CO", "es-CR", "es-CU", "es-DO", "es-EC", "es-SV", "es-GQ", "es-GT", "es-HN", "es-419", "es-MX", "es-NI", "es-PA", "es-PY", "es-PE", "es-PH", "es-PR", "es-ES_tradnl", "es-ES", "es-US", "es-UY", "zgh", "zgh-Tfng-MA", "zgh-Tfng", "ss", "ss-ZA", "ss-SZ", "sv", "sv-AX", "sv-FI", "sv-SE", "syr", "syr-SY", "shi", "shi-Tfng", "shi-Tfng-MA", "shi-Latn", "shi-Latn-MA", "dav", "dav-KE", "tg", "tg-Cyrl", "tg-Cyrl-TJ", "tzm", "tzm-Latn", "tzm-Latn-DZ", "ta", "ta-IN", "ta-MY", "ta-SG", "ta-LK", "twq", "twq-NE", "tt", "tt-RU", "te", "te-IN", "teo", "teo-KE", "teo-UG", "th", "th-TH", "bo", "bo-IN", "bo-CN", "tig", "tig-ER", "ti", "ti-ER", "ti-ET", "to", "to-TO", "ts", "ts-ZA", "tr", "tr-CY", "tr-TR", "tk", "tk-TM", "uk", "uk-UA", "hsb", "hsb-DE", "ur", "ur-IN", "ur-PK", "ug", "ug-CN", "uz-Arab", "uz-Arab-AF", "uz-Cyrl", "uz-Cyrl-UZ", "uz", "uz-Latn", "uz-Latn-UZ", "vai", "vai-Vaii", "vai-Vaii-LR", "vai-Latn-LR", "vai-Latn", "ca-ES-valencia", "ve", "ve-ZA", "vi", "vi-VN", "vo", "vo-001", "vun", "vun-TZ", "wae", "wae-CH", "cy", "cy-GB", "wal", "wal-ET", "wo", "wo-SN", "xh", "xh-ZA", "yav", "yav-CM", "ii", "ii-CN", "yi-001", "yo", "yo-BJ", "yo-NG", "dje", "dje-NE", "zu", "zu-ZA"};
        }
        private static string GetStringValue(object objectToConvert)
        {
            string result = null;
            if (objectToConvert is InArgument<string> arg)
            {
                var value = arg.Expression.ToString();

                if (!string.IsNullOrEmpty(value))
                {
                    result = value;
                }
            }
            return result;
        }
    }
}
