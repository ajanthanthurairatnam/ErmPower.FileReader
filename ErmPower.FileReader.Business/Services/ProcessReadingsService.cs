using ErmPower.FileReader.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErmPower.FileReader.Business.Services
{
    public class ProcessReadingsService : IProcessReadingsService
    {
        private readonly BusinessRules _businessRules;
        private readonly IRepository _repository;

        public ProcessReadingsService(IRepository repository, BusinessRules businessRules)
        {
            _repository = repository;
            _businessRules = businessRules;
        }

        public IEnumerable<string> GetFileReadings(string folderPath)
        {
            if (_repository.FetchAll(folderPath).Any())
            {
                foreach (var lineItem in _repository.FetchAll(folderPath).Where(_businessRules.ReadingCondition))
                {
                    yield return ($"{lineItem.FileName} {lineItem.ReadingDateTime} {lineItem.ReadingValue} {lineItem.ReadingMedianValue}");
                }
            }
        }


    }
}
