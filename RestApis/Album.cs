﻿namespace NUnitTestBandsApi.RestApis
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Album
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("record_company")]
        public string RecordCompany { get; set; }
    }

    public partial class Album
    {
        public static Album[] FromJson(string json) => JsonConvert.DeserializeObject<Album[]>(json, NUnitTestBandsApi.RestApis.AlbumConverter.Settings);
    }

    public static class AlbumSerialize
    {
        public static string ToJson(this Album[] self) => JsonConvert.SerializeObject(self, NUnitTestBandsApi.RestApis.AlbumConverter.Settings);
    }

    internal static class AlbumConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}