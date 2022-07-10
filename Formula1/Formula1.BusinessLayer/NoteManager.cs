
using Formula1.DataAccessLayer.EntityFramework;
using Formula1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.BusinessLayer
{
    public class NoteManager 
    {
        private Repository<Note> repo_note = new Repository<Note>();

        public List <Note> GetAllNote()
        {
            return repo_note.List();
        }

    }
}
