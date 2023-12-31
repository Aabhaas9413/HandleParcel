﻿using ParcelLib.Models;
using ParcelLib.Services.IServices;

namespace ParcelLib.Services
{
    public class DepartmentService : IDepartmentService
    {        
        private List<Department> _departments = new List<Department>();

        public List<Department> GetDepartments()
        {
            return _departments;
        }
        public List<Department> AddDepartment(string name, double weightThreshold)
        {
            _departments.Add(new Department(name, weightThreshold));
            _departments = _departments.OrderBy(department => department.WeightThreshold).ToList();
            return _departments;
        }

        public List<Department> RemoveDepartment(string name)
        {
            _departments.RemoveAll(d => d.Name.Equals(name));
            return _departments;
        }
    }
}
