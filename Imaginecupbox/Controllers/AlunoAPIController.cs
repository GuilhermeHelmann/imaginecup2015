using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Imaginecupbox.Models;

namespace Imaginecupbox.Controllers
{
    public class AlunoAPIController : ApiController
    {
        private ImaginecupContext db = new ImaginecupContext();

        // GET api/AlunoAPI
        public IEnumerable<Aluno> GetAlunoes()
        {
            return db.Alunos.AsEnumerable();
        }

        // GET api/AlunoAPI/5
        public Aluno GetAluno(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return aluno;
        }

        // PUT api/AlunoAPI/5
        public HttpResponseMessage PutAluno(int id, Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != aluno.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(aluno).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/AlunoAPI
        public HttpResponseMessage PostAluno(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, aluno);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = aluno.id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/AlunoAPI/5
        public HttpResponseMessage DeleteAluno(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Alunos.Remove(aluno);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, aluno);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}