﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.AlumnoServicios {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AlumnoServicios.IAlumnoService")]
    public interface IAlumnoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Add", ReplyAction="http://tempuri.org/IAlumnoService/AddResponse")]
        bool Add(SL_WCF.Alumno obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Add", ReplyAction="http://tempuri.org/IAlumnoService/AddResponse")]
        System.Threading.Tasks.Task<bool> AddAsync(SL_WCF.Alumno obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Update", ReplyAction="http://tempuri.org/IAlumnoService/UpdateResponse")]
        bool Update(SL_WCF.Alumno obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Update", ReplyAction="http://tempuri.org/IAlumnoService/UpdateResponse")]
        System.Threading.Tasks.Task<bool> UpdateAsync(SL_WCF.Alumno obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Delete", ReplyAction="http://tempuri.org/IAlumnoService/DeleteResponse")]
        bool Delete(int idAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Delete", ReplyAction="http://tempuri.org/IAlumnoService/DeleteResponse")]
        System.Threading.Tasks.Task<bool> DeleteAsync(int idAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetAll", ReplyAction="http://tempuri.org/IAlumnoService/GetAllResponse")]
        SL_WCF.Alumno[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetAll", ReplyAction="http://tempuri.org/IAlumnoService/GetAllResponse")]
        System.Threading.Tasks.Task<SL_WCF.Alumno[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetById", ReplyAction="http://tempuri.org/IAlumnoService/GetByIdResponse")]
        SL_WCF.Alumno GetById(int idAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetById", ReplyAction="http://tempuri.org/IAlumnoService/GetByIdResponse")]
        System.Threading.Tasks.Task<SL_WCF.Alumno> GetByIdAsync(int idAlumno);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlumnoServiceChannel : PL.AlumnoServicios.IAlumnoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlumnoServiceClient : System.ServiceModel.ClientBase<PL.AlumnoServicios.IAlumnoService>, PL.AlumnoServicios.IAlumnoService {
        
        public AlumnoServiceClient() {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Add(SL_WCF.Alumno obj) {
            return base.Channel.Add(obj);
        }
        
        public System.Threading.Tasks.Task<bool> AddAsync(SL_WCF.Alumno obj) {
            return base.Channel.AddAsync(obj);
        }
        
        public bool Update(SL_WCF.Alumno obj) {
            return base.Channel.Update(obj);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAsync(SL_WCF.Alumno obj) {
            return base.Channel.UpdateAsync(obj);
        }
        
        public bool Delete(int idAlumno) {
            return base.Channel.Delete(idAlumno);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAsync(int idAlumno) {
            return base.Channel.DeleteAsync(idAlumno);
        }
        
        public SL_WCF.Alumno[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Alumno[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public SL_WCF.Alumno GetById(int idAlumno) {
            return base.Channel.GetById(idAlumno);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.Alumno> GetByIdAsync(int idAlumno) {
            return base.Channel.GetByIdAsync(idAlumno);
        }
    }
}