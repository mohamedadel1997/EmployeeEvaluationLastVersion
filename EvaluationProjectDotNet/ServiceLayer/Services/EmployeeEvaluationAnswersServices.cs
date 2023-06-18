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
    public class EmployeeEvaluationAnswersServices : IEmployeeEvaluationAnswersServices
    {
        private readonly IRepository<EmployeeEvaluationAnswer> _employeeEvaluationAnswerRepository;
        private readonly IEvaluationServices _evaluationServices;
        private readonly IMapper _mapper;

        public EmployeeEvaluationAnswersServices(IRepository<EmployeeEvaluationAnswer> employeeEvaluationAnswerRepository,
                                                    IEvaluationServices evaluationServices , IMapper mapper)
        {
            this._employeeEvaluationAnswerRepository = employeeEvaluationAnswerRepository;
            this._evaluationServices = evaluationServices;
            this._mapper = mapper;
        }
        public List<EmployeeEvaluationAnswer> GetAllEmployeeEvaluationAnswers(int employeeId)
        {
            try
            {
                return _employeeEvaluationAnswerRepository
                .GetAll(ee => ee.EmployeeId == employeeId, "Employee,QuestionsEvaluation").ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertEmployeeEvaluationAnswer(List<EmployeeAnswerModel> employeeAnswerModelList)
        {
            try
            {
                var evaluationId = 0;
                foreach (var employeeAnswerModel in employeeAnswerModelList)
                {
                    var insertedData = _mapper.Map<EmployeeAnswerModel, EmployeeEvaluationAnswer>(employeeAnswerModel);
                    _employeeEvaluationAnswerRepository.Insert(insertedData);
                    if (evaluationId == 0)
                    {
                        evaluationId = insertedData.QuestionsEvaluation.EvaluationId;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateEmployeeEvaluationAnswer(EmployeeEvaluationAnswer employeeEvaluationAnswer)
        {
            try
            {
                _employeeEvaluationAnswerRepository.Update(employeeEvaluationAnswer);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
