using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularMongo.Models;
using DataAccess;
using DataModels;
using DataModels.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkorderController : ControllerBase
    {
        private readonly IWorkOrderOperations _workOrderOperations;
        private readonly WorkorderTasks _tasks;
        public WorkorderController(IWorkOrderOperations operations, WorkorderTasks tasks)
        {
            _workOrderOperations = operations;
            _tasks = tasks;
        }
        [HttpGet]
        public async Task<List<WorkorderViewModel>> Get()
        {
            WorkOrderSearchCriteria criteria = new WorkOrderSearchCriteria();
            var result=_workOrderOperations.GetFilteredWorkOrderDataCollection(criteria);
            var output = await result;
            List<WorkorderViewModel> vmList = _tasks.ConvertCollectionToViewModel(output);
            return vmList;
        }
        [HttpPost]
        public async Task<bool> Post()
        {
           Task<bool> result =  _workOrderOperations.InsertWorkOrderCollectionAsync();
           bool success= await result;
            return success;
        }

    }
}
