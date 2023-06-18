using AutoMapper;
using DomainLayer;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class QuestionsEvaluationServices : IQuestionsEvaluationServices
    {
        private readonly IRepository<QuestionsEvaluation> _questionsEvaluationRepository;
        private readonly IMapper _mapper;

        public QuestionsEvaluationServices(IRepository<QuestionsEvaluation> questionsEvaluationRepository, IMapper mapper)
        {
            this._questionsEvaluationRepository = questionsEvaluationRepository;
            this._mapper = mapper;
        }
        public List<QuestionsForEvaluationModel> GetAllQuestionsForEvaluation(int evaluationId)
        {
            try
            {
                var QuestionsForEvaluationList = _questionsEvaluationRepository
                    .GetAll(e => e.EvaluationId == evaluationId, "Questions").ToList();
                if (QuestionsForEvaluationList.Count != 0)
                {
                    List<QuestionsForEvaluationModel> ResultList = new List<QuestionsForEvaluationModel>();
                    foreach (var item in QuestionsForEvaluationList)
                    {
                        QuestionsForEvaluationModel tmp = new QuestionsForEvaluationModel()
                        {
                            Id = item.Id,
                            EvaluationId = item.EvaluationId,
                            QuestionId = item.QuestionId,
                            Question = item.Questions.Question
                        };
                        ResultList.Add(tmp);

                    }
                    return ResultList;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertQuestionForEvaluation(List<QuestionEvaluationModel> questionEvaluation)
        {
            try
            {
                if (questionEvaluation.Count != 0)
                {
                    foreach (var question in questionEvaluation)
                    {
                        var insertedData = _mapper.Map<QuestionEvaluationModel, QuestionsEvaluation>(question);
                        _questionsEvaluationRepository.Insert(insertedData);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveQuestionFromEvaluation(int id)
        {
            try
            {
                var deletedData = _questionsEvaluationRepository.Get(id);
                if (deletedData != null)
                {
                    _questionsEvaluationRepository.Delete(deletedData);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
