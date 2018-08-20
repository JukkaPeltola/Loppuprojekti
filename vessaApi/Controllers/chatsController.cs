using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using vessaApi.Models;

namespace vessaApi.Controllers
{
    public class chatsController : ApiController
    {
        private Model db = new Model();

        // GET: api/chats
        public IEnumerable<chat> Getchats()
        {
            return db.chats.ToList();
        }

        // GET: api/chats/5
        [ResponseType(typeof(chat))]
        public IHttpActionResult Getchat(int id)
        {
            chat chat = db.chats.Find(id);
            if (chat == null)
            {
                return NotFound();
            }

            return Ok(chat);
        }

        // PUT: api/chats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putchat(int id, chat chat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chat.chat_id)
            {
                return BadRequest();
            }

            db.Entry(chat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!chatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/chats
        [ResponseType(typeof(chat))]
        public IHttpActionResult Postchat(chat chat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.chats.Add(chat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chat.chat_id }, chat);
        }

        // DELETE: api/chats/5
        [ResponseType(typeof(chat))]
        public IHttpActionResult Deletechat(int id)
        {
            chat chat = db.chats.Find(id);
            if (chat == null)
            {
                return NotFound();
            }

            db.chats.Remove(chat);
            db.SaveChanges();

            return Ok(chat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool chatExists(int id)
        {
            return db.chats.Count(e => e.chat_id == id) > 0;
        }
    }
}