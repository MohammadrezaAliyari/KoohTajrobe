using System;
using System.Collections.Generic;


namespace KoohTajrobe.Model.User.Entities
{
    public class SurveyRow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ModifyDateTime { get; set; }
        //public Survey Survey { get; set; }
        public List<SurveyRowDetail> surveyRowDetails { get; set; }
    }
}
