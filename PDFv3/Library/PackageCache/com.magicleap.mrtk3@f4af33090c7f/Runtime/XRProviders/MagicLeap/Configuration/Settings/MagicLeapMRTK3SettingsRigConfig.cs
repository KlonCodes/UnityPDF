// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
// Copyright (c) (2018-2022) Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Software License Agreement, located here: https://www.magicleap.com/software-license-agreement-ml2
// Terms and conditions applicable to third-party materials accompanying this distribution may also be found in the top-level NOTICE file appearing herein.
// %COPYRIGHT_END%
// ---------------------------------------------------------------------
// %BANNER_END%

#if UNITY_XR_MAGICLEAP_PROVIDER
using UnityEngine;
using UnityEngine.XR.MagicLeap;

namespace MagicLeap.MRTK.Settings
{
    /// <summary>
    /// Provides settings for the runtime configuration of the MRTK XR Rig specific to when
    /// using the Magic Leap XR Provider.
    /// </summary>
    public sealed class MagicLeapMRTK3SettingsRigConfig : MagicLeapMRTK3SettingsRigConfigBase
    {
        private const uint RigConfigFileVersion = 1;

        [SerializeField]
        [HideInInspector]
        private uint version = RigConfigFileVersion;
        public uint Version => version;

        /// <inheritdoc/>
        public override bool CompatibleWithActiveXRLoader => MLDevice.IsMagicLeapLoaderActive();

#if UNITY_EDITOR

        /// <inheritdoc/>
        public override string SettingsXRProviderLabel => MagicLeapMRTK3Settings.XRProviderOption.MagicLeap.ToString();

        /// <inheritdoc/>
        public override bool CompatibleWithSelectedXRProviderInEditor(MagicLeapMRTK3Settings.XRProviderOption selectedXRProvider)
        {
            return selectedXRProvider == MagicLeapMRTK3Settings.XRProviderOption.MagicLeap;
        }

#endif // UNITY_EDITOR

    }
}
#endif // UNITY_XR_MAGICLEAP_PROVIDER