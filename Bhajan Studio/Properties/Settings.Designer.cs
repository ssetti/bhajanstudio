﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bhajans.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Database\\sai_bhajans" +
            "5.mdb")]
        public string sai_bhajans5ConnectionString {
            get {
                return ((string)(this["sai_bhajans5ConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Before")]
        public string InsertBeforeOrAfter {
            get {
                return ((string)(this["InsertBeforeOrAfter"]));
            }
            set {
                this["InsertBeforeOrAfter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int ReferenceSlideIndex {
            get {
                return ((int)(this["ReferenceSlideIndex"]));
            }
            set {
                this["ReferenceSlideIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public int TitleTextBoxIndex {
            get {
                return ((int)(this["TitleTextBoxIndex"]));
            }
            set {
                this["TitleTextBoxIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int BodyTextBoxIndex {
            get {
                return ((int)(this["BodyTextBoxIndex"]));
            }
            set {
                this["BodyTextBoxIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int BhajanNumberTextBoxIndex {
            get {
                return ((int)(this["BhajanNumberTextBoxIndex"]));
            }
            set {
                this["BhajanNumberTextBoxIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int NextBhajanTextBoxIndex {
            get {
                return ((int)(this["NextBhajanTextBoxIndex"]));
            }
            set {
                this["NextBhajanTextBoxIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int TranslationTextBoxIndex {
            get {
                return ((int)(this["TranslationTextBoxIndex"]));
            }
            set {
                this["TranslationTextBoxIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dimensions=25:25:675:75,Font=Constantia:40:bold,Color=204:255:204")]
        public string TitleTextBoxCharacteristics {
            get {
                return ((string)(this["TitleTextBoxCharacteristics"]));
            }
            set {
                this["TitleTextBoxCharacteristics"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dimensions=25:100:675:300,Font=Constantia:26:bold,Color=204:255:204")]
        public string BodyTextBoxCharacteristics {
            get {
                return ((string)(this["BodyTextBoxCharacteristics"]));
            }
            set {
                this["BodyTextBoxCharacteristics"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dimensions=25:400:675:100,Font=Constantia:16,Color=204:255:204")]
        public string TranslationTextBoxCharacteristics {
            get {
                return ((string)(this["TranslationTextBoxCharacteristics"]));
            }
            set {
                this["TranslationTextBoxCharacteristics"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dimensions=25:500:40:20,Font=Constantia:18,Color=204:255:204")]
        public string BhajanNumberTextBoxCharacteristics {
            get {
                return ((string)(this["BhajanNumberTextBoxCharacteristics"]));
            }
            set {
                this["BhajanNumberTextBoxCharacteristics"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dimensions=400:500:300:20,Font=Constantia:18,Color=204:255:204")]
        public string NextBhajanTextBoxCharacteristics {
            get {
                return ((string)(this["NextBhajanTextBoxCharacteristics"]));
            }
            set {
                this["NextBhajanTextBoxCharacteristics"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseReferenceSlide {
            get {
                return ((bool)(this["UseReferenceSlide"]));
            }
            set {
                this["UseReferenceSlide"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Songs")]
        public string SongsFolder {
            get {
                return ((string)(this["SongsFolder"]));
            }
            set {
                this["SongsFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Bhajans")]
        public string OutputFolder {
            get {
                return ((string)(this["OutputFolder"]));
            }
            set {
                this["OutputFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Template\\Bhajans.ppt")]
        public string PowerPointTemplateLocation {
            get {
                return ((string)(this["PowerPointTemplateLocation"]));
            }
            set {
                this["PowerPointTemplateLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool BhajanStartsWithFlag {
            get {
                return ((bool)(this["BhajanStartsWithFlag"]));
            }
            set {
                this["BhajanStartsWithFlag"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool SearchTitleOnlyFlag {
            get {
                return ((bool)(this["SearchTitleOnlyFlag"]));
            }
            set {
                this["SearchTitleOnlyFlag"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool HideRowsWithEmptyScalesFlag {
            get {
                return ((bool)(this["HideRowsWithEmptyScalesFlag"]));
            }
            set {
                this["HideRowsWithEmptyScalesFlag"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Template\\BhajansEmpty.ppt")]
        public string PowerPointEmptyTemplateLocation {
            get {
                return ((string)(this["PowerPointEmptyTemplateLocation"]));
            }
            set {
                this["PowerPointEmptyTemplateLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Next: (%scale%) %leader%-%title%")]
        public string NextBhajanFormat {
            get {
                return ((string)(this["NextBhajanFormat"]));
            }
            set {
                this["NextBhajanFormat"] = value;
            }
        }
    }
}
