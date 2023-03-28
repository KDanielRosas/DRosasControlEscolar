using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SL_WebApi.Controllers
{
    public class MateriaController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materias/GetAll")]
        public IHttpActionResult Index()
        {           
            
            ML.Result result = BL.Materias.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }                              
        }//GetAll

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Materias/Add")]
        public IHttpActionResult Add([FromBody]ML.Materias materia)
        {
            ML.Result result = BL.Materias.Add(materia);
            if (result.Correct)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }//Add

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Materias/Update")]
        public IHttpActionResult Update([FromBody]ML.Materias materia)
        {
            ML.Result result = BL.Materias.Update(materia);
            if (result.Correct)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }//Update

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Materias/Delete")]
        public IHttpActionResult Delete(int idMateria)
        {
            ML.Result result = BL.Materias.Delete(idMateria);
            if (result.Correct)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }//Delete

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materias/GetById")]
        public IHttpActionResult GetById(int idMateria)
        {
            ML.Result result = BL.Materias.GetById(idMateria);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }//GetById
    }
}