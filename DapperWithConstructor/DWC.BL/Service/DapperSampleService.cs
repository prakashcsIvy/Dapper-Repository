﻿using DWC.DL.Repositories;
using DWC.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWC.BL.Service
{
    public interface IDapperSampleService
    {
        List<SADM_Users> sample();
    }
    public class DapperSampleService : IDapperSampleService
    {
        private readonly IDapperSampleRepository _repository;

        public DapperSampleService(IDapperSampleRepository repository)
        {
            _repository = repository;
        }

        public List<SADM_Users> sample()
        {
           return _repository.sample();
        }
    }
}
