﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using ApiAnalysis;
using Microsoft.TemplateEngine.Abstractions;
using Newtonsoft.Json;

namespace TemplateValidator
{
    /// <summary>
    /// This class is used as a reference for ITemplateInfo. We don't deserialize to it directly but the Templating library does.
    /// This class also stores attribute information used by the analyzer.
    /// For more about the contents of a template file see https://github.com/dotnet/templating/wiki/%22Runnable-Project%22-Templates#identity-optional
    /// </summary>
    public class ValidationTemplateInfo : ITemplateInfo
    {
        [ApiAnalysisValidValues("Microsoft", "Microsoft Community Contribution", "Laurent Bugnion", "Laurent Bugnion + Community Contribution", "Nigel Sampson")]
        public string Author { get; set; }

        [ApiAnalysisOptional]
        public string Description { get; set; }

        public IReadOnlyList<string> Classifications { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public string DefaultName { get; set; }

        [ApiAnalysisOptional]
        public string Identity { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public Guid GeneratorId { get; set; }

        [ApiAnalysisOptional]
        public string GroupIdentity { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public int Precedence { get; set; }

        public string Name { get; set; }

        [ApiAnalysisShouldNotBeInJson("Is not used. We use `Name` for identifying purposes.")]
        public string ShortName { get; set; }

        // This is how the interface defines the Tags property
        [JsonIgnore]
        public IReadOnlyDictionary<string, ICacheTag> Tags { get; }

        // We just use strings for tags. The template engine uses a converter but this is fine for testing purposes
        [ApiAnalysisMandatoryKeys("language", "type", "wts.type")]
        [ApiAnalysisOptionalKeys("wts.displayOrder", "wts.compositionOrder", "wts.framework", "wts.projecttype", "wts.version", "wts.genGroup", "wts.rightClickEnabled", "wts.compositionFilter", "wts.licenses", "wts.group", "wts.multipleInstance", "wts.dependencies", "wts.defaultInstance", "wts.export.baseclass", "wts.export.setter", "wts.isHidden", "wts.fileNameSearch1", "wts.fileNameSearch2", "wts.fileNameSearch3", "wts.fileNameSearch4", "wts.fileNameSearch5", "wts.fileNameSearch6", "wts.fileNameSearch7", "wts.fileNameSearch8", "wts.fileNameSearch9", "wts.fileNameSearch0")]
        [JsonProperty("tags")]
        public IReadOnlyDictionary<string, string> TemplateTags { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public IReadOnlyDictionary<string, ICacheParameter> CacheParameters { get; set; }

        [ApiAnalysisOptional]
        public IReadOnlyList<ITemplateParameter> Parameters { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public Guid ConfigMountPointId { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public string ConfigPlace { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public Guid LocaleConfigMountPointId { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public string LocaleConfigPlace { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public Guid HostConfigMountPointId { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public string HostConfigPlace { get; set; }

        [ApiAnalysisShouldNotBeInJson("We don't use it.")]
        public string ThirdPartyNotices { get; set; }

        [ApiAnalysisOptional]
        public IReadOnlyDictionary<string, IBaselineInfo> BaselineInfo { get; set; }

        [ApiAnalysisOptional]
        public List<PrimaryOutput> PrimaryOutputs { get; set; }

        [ApiAnalysisOptional]
        public IReadOnlyDictionary<string, SymbolInfo> Symbols { get; set; }

        public string SourceName { get; set; }

        [ApiAnalysisOptional]
        public bool PlaceholderFilename { get; set; }

        [ApiAnalysisOptional]
        public bool PreferNameDirectory { get; set; }

        [ApiAnalysisOptional]
        public List<string> Guids { get; set; }
    }
}
