﻿using System;
using System.Collections.Generic;

namespace AdjustSdk
{
    public class AdjustConfig
    {
        public const string AdjustUrlStrategyChina = "china";
        public const string AdjustUrlStrategyIndia = "india";

        public const string AdjustDataResidencyEU = "data-residency-eu";
        public const string AdjustDataResidencyTR = "data-residency-tr";
        public const string AdjustDataResidencyUS = "data-residency-us";

        public const string AdjustAdRevenueSourceAppLovinMAX = "applovin_max_sdk";
        public const string AdjustAdRevenueSourceMopub = "mopub";
        public const string AdjustAdRevenueSourceAdMob = "admob_sdk";
        public const string AdjustAdRevenueSourceIronSource = "ironsource_sdk";
        public const string AdjustAdRevenueSourceAdmost = "admost_sdk";
        public const string AdjustAdRevenueSourceUnity = "unity_sdk";
        public const string AdjustAdRevenueSourceHeliumChartboost = "helium_chartboost_sdk";
        public string AppToken { get; private set; }
        public string DefaultTracker { get; set; }
        public string ExternalDeviceId { get; set; }
        public bool? IsCoppaComplianceEnabled { get; set; }
        public bool? IsSendingInBackgroundEnabled { get; set; }
        public bool? IsCostDataInAttributionEnabled { get; set; }
        public bool? IsDeviceIdsReadingOnceEnabled { get; set; }
        public bool? IsDeferredDeeplinkOpeningEnabled { get; set; }
        public bool? IsAppTrackingTransparencyUsageEnabled { get; set; }
        public bool? IsFirstSessionDelayEnabled { get; set; }
        public bool? AllowSuppressLogLevel { get; private set; }
        public bool? IsDataResidency { get; private set; }
        public bool? ShouldUseSubdomains { get; private set; }
        public int? EventDeduplicationIdsMaxSize { get; set; }
        public List<string> UrlStrategyDomains { get; private set; }
        public AdjustLogLevel? LogLevel { get; set; }
        public AdjustEnvironment Environment { get; private set; }
        public AdjustStoreInfo StoreInfo { get; set; }
        public Action<AdjustAttribution> AttributionChangedDelegate { get; set; }
        public Action<AdjustEventSuccess> EventSuccessDelegate { get; set; }
        public Action<AdjustEventFailure> EventFailureDelegate { get; set; }
        public Action<AdjustSessionSuccess> SessionSuccessDelegate { get; set; }
        public Action<AdjustSessionFailure> SessionFailureDelegate { get; set; }
        public Action<string> DeferredDeeplinkDelegate { get; set; }
        public Action<Dictionary<string, string>> SkanUpdatedDelegate { get; set; }

        // iOS specific
        public bool? IsAdServicesEnabled { get; set; }
        public bool? IsIdfaReadingEnabled { get; set; }
        public bool? IsSkanAttributionEnabled { get; set; }
        public bool? IsLinkMeEnabled { get; set; }
        public int? AttConsentWaitingInterval { get; set; }

        // Android specific
        public bool? IsPlayStoreKidsComplianceEnabled { get; set; }
        public bool? IsPreinstallTrackingEnabled { get; set; }
        public string PreinstallFilePath { get; set; }
        public string FbAppId { get; set; }

        public AdjustConfig(string appToken, AdjustEnvironment environment)
        {
            this.AppToken = appToken;
            this.Environment = environment;
        }

        public AdjustConfig(string appToken, AdjustEnvironment environment, bool allowSuppressLogLevel)
        {
            this.AppToken = appToken;
            this.Environment = environment;
            this.AllowSuppressLogLevel = allowSuppressLogLevel;
        }

        public void SetUrlStrategy(
            List<string> urlStrategyDomains,
            bool shouldUseSubdomains,
            bool isDataResidency)
        {
            this.UrlStrategyDomains = urlStrategyDomains;
            this.ShouldUseSubdomains = shouldUseSubdomains;
            this.IsDataResidency = isDataResidency;
        }
        public void setLogLevel(AdjustLogLevel logLevel)
        {
            this.LogLevel = logLevel;
        }
        public void setSendInBackground(bool sendInBackground)
        {
            this.IsSendingInBackgroundEnabled = sendInBackground;
        }
    }
}
