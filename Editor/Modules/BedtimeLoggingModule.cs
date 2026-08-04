using System;
using System.ComponentModel;

namespace BedtimeCore.NestBuilder
{
	[Serializable]
	public class BedtimeLoggingModule : ISettingsModule
	{
		#if BEDTIME_LOGGING
		[Category("Bedtime Logging"), Recompile]
		public BoolSetting BedLogEnabled = new();

		[Category("Bedtime Logging")]
		public EnumSetting<LogLevelEnum> LogLevel = new(BedtimeCore.ProjectSettings.LogSettings.SetLogLevelBuild);

		[UnityEditor.Callbacks.DidReloadScripts]
		private static void OnScriptReload()
		{
			if (Builder.IsBuilding)
			{
				return;
			}
			
			BedtimeCore.ProjectSettings.LogSettingsUtility.SetLogDefine();
		}
		#endif
	}
}