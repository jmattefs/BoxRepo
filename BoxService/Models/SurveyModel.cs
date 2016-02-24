using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BoxService.Models
{
    public class SurveyModel
    {
        public int ID { get; set; }
        public int gender { get; set; }
      
        public int age { get; set; }
        public int maxMoney { get; set; }
        public bool alcohol {get; set;}
        public bool presentable { get; set; }
        public bool books { get; set; }
        public bool candles { get; set; }
        public bool candy { get; set; }
        public bool clothes { get; set; }
        public bool coffee { get; set; }
        public bool fitness { get; set; }
        public bool games { get; set; }
        public bool movies { get; set; }
        public bool music { get; set; }
        public bool sports { get; set; }
        public int active { get; set; }
        public int candle { get; set; }
        public int entertainment { get; set; }
        public int foodORdrink { get; set; }
        public int appearance { get; set; }

    }
}