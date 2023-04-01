using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace tsx_react_project
{

    public enum StoneType
    {
        Amethyst,
        LapisLazuli,
        Malachite,
        LakeSuperiorAgate,
        BlackAgate_Onyx,
        SurpriseMe,
    }

    public enum StoneCabShape

    {
        Oval,
        Round,
        Drop,
        LargeDrop,
        Trapezoid,
        SurpriseMe,

    }

    public class Stone
    {
        public int id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StoneType type { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StoneCabShape shape { get; set; }

    }

}