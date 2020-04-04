using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using KoohTajrobe.DataAccess;
using KoohTajrobe.Model.survey.Interfaces;
using KoohTajrobe.Model.User.Entities;
using Microsoft.EntityFrameworkCore;


namespace KoohTajrobe.Repository.Survey
{
    class SurveyRepository : BaseRepository,IRepositorySurvey
    {

        public SurveyRepository(KoohTajrobeDbContext koohTajrobeDbContext) 
            : base(koohTajrobeDbContext)
        {
        }

        public async Task Insert(Model.survey.Survey survey)
        {
           await KoohTajrobeDbContext.Set<Model.survey.Survey>().AddAsync(survey);
        }

        public async Task Update(Model.survey.Survey survey)
        {
            var existSurvey = await KoohTajrobeDbContext.Set<Model.survey.Survey>()
                .FirstOrDefaultAsync(x => x.Id == survey.Id);

            if (existSurvey == null)
            {
                throw new KeyNotFoundException();
            }

            existSurvey.Title = survey.Title;
            existSurvey.StartDateTime = survey.StartDateTime;
            existSurvey.EndDateTime = survey.EndDateTime;
            existSurvey.userRole = survey.userRole;

        }

        public async Task<Model.survey.Survey> Get(Model.survey.Survey survey)
        {
            var resultSurvey = await KoohTajrobeDbContext.Set<Model.survey.Survey>()
                .FirstOrDefaultAsync(x => x.Id == survey.Id);
            return resultSurvey;
        }

        public async Task<List<Model.survey.Survey>> GetAll()
        {
            return await KoohTajrobeDbContext.Set<Model.survey.Survey>().ToListAsync();
        }

        public async Task<List<Model.survey.Survey>> GetAllByUserRoleId(UserRole userRole)
        {
            return await KoohTajrobeDbContext.Set<Model.survey.Survey>()
                .Where(x => x.userRole.Id == userRole.Id)
                .ToListAsync();
        }

        public async Task Delete(Model.survey.Survey survey)
        {
            var result = await KoohTajrobeDbContext.Set<Model.survey.Survey>()
                .FirstOrDefaultAsync(x => x.Id == survey.Id);

            KoohTajrobeDbContext.Set<Model.survey.Survey>().Remove(result);

        }

        public async Task InsertSurveyRow(SurveyRow surveyRow)
        {
            await KoohTajrobeDbContext.Set<SurveyRow>().AddAsync(surveyRow);
        }

        public async Task InsertSurveyRows(List<SurveyRow> surveyRows)
        {
            await KoohTajrobeDbContext.Set<SurveyRow>().AddRangeAsync(surveyRows);
        }

        public async Task UpdateSurveyRow(SurveyRow surveyRow)
        {
            SurveyRow _surveyRow =
                await KoohTajrobeDbContext.Set<SurveyRow>()
                    .FirstOrDefaultAsync(x => x.Id == surveyRow.Id);
            if (_surveyRow == null)
            {
                throw new Exception();
            }

            _surveyRow.Title = surveyRow.Title;
            _surveyRow.ModifyDateTime = DateTime.Now;
            _surveyRow.surveyRowDetails = surveyRow.surveyRowDetails;

        }

        public async Task<SurveyRow> GetSurveyRow(SurveyRow surveyRow)
        {
            return await KoohTajrobeDbContext.Set<SurveyRow>()
                .FirstOrDefaultAsync(x => x.Id == surveyRow.Id);
        }

        public async Task<Model.survey.Survey> GetAllSurveyRowBySurveyId(Model.survey.Survey survey)
        {
            return await KoohTajrobeDbContext.Set<Model.survey.Survey>().Include(x => x.surveyRows)
                .FirstOrDefaultAsync(x => x.Id == survey.Id);
        }

        public async Task DeleteSurveyRow(SurveyRow surveyRow)
        {
            var result = await KoohTajrobeDbContext.Set<SurveyRow>()
                .FirstOrDefaultAsync(x => x.Id == surveyRow.Id);
            KoohTajrobeDbContext.Set<SurveyRow>().Remove(result);
        }

        public async Task InsertSurveyRowDetail(SurveyRowDetail surveyRowDetail)
        {
            await KoohTajrobeDbContext.Set<SurveyRowDetail>().AddAsync(surveyRowDetail);
        }

        public async Task InsertSurveyRowDetails(List<SurveyRowDetail> surveyRowDetails)
        {
            await KoohTajrobeDbContext.Set<SurveyRowDetail>().AddRangeAsync(surveyRowDetails);
        }

        public async Task UpdateSurveyRowDetail(SurveyRowDetail surveyRowDetail)
        {
            var result = await KoohTajrobeDbContext.Set<SurveyRowDetail>()
                .FirstOrDefaultAsync(x => x.Id == surveyRowDetail.Id);

            result.Title = surveyRowDetail.Title;
            result.ModifyDate= DateTime.Now;
        }

        public async Task<SurveyRowDetail> GetSurveyRowDetail(SurveyRowDetail surveyRowDetail)
        {
            return await KoohTajrobeDbContext.Set<SurveyRowDetail>()
                .FirstOrDefaultAsync(x => x.Id == surveyRowDetail.Id);
        }

        public async Task<List<SurveyRowDetail>> GetSurveyRowDetailBySurveyRow(SurveyRow surveyRow)
        {
            throw new NotImplementedException();

        }

        public async Task DeleteSurveyRowDetail(SurveyRowDetail surveyRowDetail)
        {
            var result = await KoohTajrobeDbContext.Set<SurveyRowDetail>()
                .FirstOrDefaultAsync(x => x.Id == surveyRowDetail.Id);

            KoohTajrobeDbContext.Set<SurveyRowDetail>().Remove(result);
        }

        
    }
}
