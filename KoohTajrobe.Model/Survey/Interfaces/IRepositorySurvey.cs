using KoohTajrobe.Model.User.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KoohTajrobe.Model.User;

namespace KoohTajrobe.Model.survey.Interfaces
{
    public interface IRepositorySurvey
    {
        Task Insert(Survey survey);
        Task Update(Survey survey);
        Task<Survey> Get(Survey survey);
        Task<List<Survey>> GetAll();
        Task<List<Survey>> GetAllByUserRoleId(UserRole userRole);
        Task Delete(Survey survey);


        Task InsertSurveyRow(SurveyRow surveyRow);
        Task InsertSurveyRows(List<SurveyRow> surveyRows);
        Task UpdateSurveyRow(SurveyRow surveyRow);
        Task<SurveyRow> GetSurveyRow(SurveyRow surveyRow);
        Task<Survey> GetAllSurveyRowBySurveyId(Survey survey);
        Task DeleteSurveyRow(SurveyRow surveyRow);


        Task InsertSurveyRowDetail(SurveyRowDetail surveyRowDetail);
        Task InsertSurveyRowDetails(List<SurveyRowDetail> surveyRowDetails);
        Task UpdateSurveyRowDetail(SurveyRowDetail surveyRowDetail);
        Task<SurveyRowDetail> GetSurveyRowDetail(SurveyRowDetail surveyRowDetail);
        Task<List<SurveyRowDetail>> GetSurveyRowDetailBySurveyRow(SurveyRow surveyRow);
        Task DeleteSurveyRowDetail(SurveyRowDetail surveyRowDetail);

    }
}
