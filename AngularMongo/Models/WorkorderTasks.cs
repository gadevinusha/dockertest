using AngularMongo.Models;
using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class WorkorderTasks
    {
        public List<WorkorderViewModel> ConvertCollectionToViewModel(IList<WorkOrderCollection> collection)
        {
            List<WorkorderViewModel> result = new List<WorkorderViewModel>();
            WorkorderViewModel vm = null;

            try
            {
                foreach (var item in collection)
                {
                    vm = new WorkorderViewModel();
                    vm.Workorder = item.WORKORDER != null ? item.WORKORDER.MaintenanceId : string.Empty;
                    vm.Status = item.WORKORDER != null ? item.WORKORDER.Status : string.Empty;
                    vm.TestCode = item.WORKORDER != null ? item.WORKORDER.TestCode : string.Empty;
                    vm.TestLevel = item.WORKORDER != null ? item.WORKORDER.TestLevel : 0;
                    vm.EquipmentCode = item.EQUIPMENT != null ? item.EQUIPMENT.Equipment_Code : string.Empty;
                    vm.AUDesc = item.ORGANIZATION_DETAILS != null ? item.ORGANIZATION_DETAILS.AUDesc : string.Empty;
                    vm.AU = item.ORGANIZATION_DETAILS != null ? item.ORGANIZATION_DETAILS.AU : 0;
                    vm.AssignedTo = item.WORKORDER != null ? item.WORKORDER.AssignedTo : string.Empty;
                    vm.ActualEndDate = item.WORKORDER != null ? item.WORKORDER.WODate : DateTime.MinValue;
                    result.Add(vm);
                }
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
