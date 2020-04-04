using KoohTajrobe.Model.User.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoohTajrobe.Model.survey
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public UserRole userRole { get; set; }
        public List<SurveyRow> surveyRows { get; set; }

    }
}
